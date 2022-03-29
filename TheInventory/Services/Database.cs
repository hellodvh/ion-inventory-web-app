using MySql.Data.MySqlClient;
using System.Text;
using TheInventory.Models;
using System.ComponentModel.DataAnnotations;

namespace TheInventory.Services
{
    public class Database
    {
        //Configuration to connect to our localhost database.
        private static string serverConfiguration = @"server=localhost;userid=root;password=;database=ioninventorydb;";

        //Test our database connection is working by returning the version of the database.
        public static string GetVersion()
        {
            //Create and open a new connection the database using the Config and NuGet Package.
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            return con.ServerVersion;
        }

        /*-------------------------------------------------------------------------------------
        //Get All the Materials (blocks)
        -------------------------------------------------------------------------------------*/
        public static List<Material> GetAllMaterials()
        {
            //Create & Open the Database Connection
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            //Setup Query
            string sql = "SELECT * FROM materials";
            using var cmd = new MySqlCommand(sql, con);//Perform this command when connection is established.

            //Create an instance of our command result that can be read in C#.
            using MySqlDataReader reader = cmd.ExecuteReader();
            //Initiat the return list
            var results = new List<Material>();

            //While-loop: Go through the readable data and do this for each entry.
            while(reader.Read())
            {
                var material = new Material(reader.GetInt32(3))
                {
                    Name = reader.GetString(0), // index of column order
                    MaterialType = reader.GetString(1),
                    ImageUrl = reader.GetString(2),
                };
                results.Add(material);
            }
            //Return the final result after adding each readable row.
            return results;
        }

        /*-------------------------------------------------------------------------------------
        //Update the count of materials
        -------------------------------------------------------------------------------------*/
        public static void UpdateMaterialCount(string name, int newCount)
        {
            //Establish a connection to the database.
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            //Sql query
            string sql = "UPDATE `materials` SET `count`= @count WHERE `name` = @name";
            using var cmd = new MySqlCommand(sql, con);

            //Add the actual values by replacing the @placeholders
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@count", newCount);
            //Prepare the Command.
            cmd.Prepare();
            //Execute
            cmd.ExecuteNonQuery();
        }

        /*-------------------------------------------------------------------------------------
        //Get List of All Recipes
        -------------------------------------------------------------------------------------*/

        public static List<Recipe> GetAllRecipes()
        {
            //create & open the db connection
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            //setup query
            string sql = "SELECT * FROM recipes";
            using var cmd = new MySqlCommand(sql, con); //perform this new command which is sql and do it in the connnect established.

            //creates a instance of our command result that can be read in C#.
            using MySqlDataReader reader = cmd.ExecuteReader();

            //init our return list
            var results = new List<Recipe>();

            //go through the readable data and do this for each entry
            while (reader.Read())
            {
                var recipe = new Recipe(reader.GetInt32(2))
                {
                    Name = reader.GetString(0), //0 = index of our column order
                    RecipeType = reader.GetString(1),
                };

                var ingredients = new List<string>();
                ingredients.Add(reader.GetString(3)); // ingredient 1
                ingredients.Add(reader.GetString(4)); // ingredient 2
                ingredients.Add(reader.GetString(5)); // ingredient 3
                ingredients.Add(reader.GetString(6)); // ingredient 4
                ingredients.Add(reader.GetString(7)); // ingredient 5
                ingredients.Add(reader.GetString(8)); // ingredient 6
                ingredients.Add(reader.GetString(9)); // ingredient 7
                ingredients.Add(reader.GetString(10)); // ingredient 8

                recipe.Ingredients = ingredients;

                results.Add(recipe);
            }
            //return the final results after adding each readable row
            return results;
        }

        /*-------------------------------------------------------------------------------------
        //Craft Recipe
        -------------------------------------------------------------------------------------*/ 

        public static bool CraftRecipe(string nameId, int newCount, List<string> ingredients, string verify)
        {

            if(CheckVerifyCode(nameId, verify))
            {
                //Remove the ingredients
                UpdateMaterialCountAfterCraft(ingredients);
                //establich connection to db
                using var con = new MySqlConnection(serverConfiguration);
                con.Open();
                //sql query
                string sql = "UPDATE `recipes` SET `count`= @count WHERE `name` = @name";
                using var cmd = new MySqlCommand(sql, con);
                //addming the actual values by replacing the @placeholders
                cmd.Parameters.AddWithValue("@name", nameId);
                cmd.Parameters.AddWithValue("@count", newCount);
                //Prepare Command
                cmd.Prepare();
                //Execute
                cmd.ExecuteNonQuery();

                return true;
            }
            else
            {
                return false;
            }
            
        }

        /*-------------------------------------------------------------------------------------
        //Check Verify Code
        -------------------------------------------------------------------------------------*/
        private static bool CheckVerifyCode(string nameId, string verifyInput)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            var sql = "SELECT verifycode FROM recipes WHERE name = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", nameId);

            using MySqlDataReader reader = cmd.ExecuteReader();

            var databaseVerifyCode = "";

            while (reader.Read())
            {
                databaseVerifyCode = reader.GetString(0);
            }
            con.Close();

            
            var data = Encoding.ASCII.GetBytes(verifyInput);
            var hashData = new XSystem.Security.Cryptography.SHA1Managed().ComputeHash(data);

            var userInputHashCode = string.Empty;

            foreach (var key in hashData)
            {
                userInputHashCode += key.ToString("X2");
            }
            Console.WriteLine($"--------Database Verify Code: {databaseVerifyCode}");
            Console.WriteLine($"--------Input Verify Code: {userInputHashCode}");

            if (databaseVerifyCode.ToUpper() == userInputHashCode)
            {
                Console.WriteLine("Correct");
                return true;
            }
            else
            {
                Console.WriteLine("InCorrect");
                return false;
            }
        }

        /*-------------------------------------------------------------------------------------
        //Update Material Count After Crating
        -------------------------------------------------------------------------------------*/
        public static void UpdateMaterialCountAfterCraft(List<string> ingredients)
        {
            //establich connection to db
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            foreach (string material in ingredients)
            {
                if (material != "")
                {
                    Console.WriteLine("Current Ingredient Loop: " + material);
                    int currentCount = GetCountOfMaterial(material);

                    //sql query
                    string sql = "UPDATE `materials` SET `count`= @count WHERE `name` = @name";
                    using var cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@name", material);
                    cmd.Parameters.AddWithValue("@count", currentCount - 1);
                    //Prepare Command
                    cmd.Prepare();
                    //Execute
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /*-------------------------------------------------------------------------------------
        //Get Count Of Material
        -------------------------------------------------------------------------------------*/
        public static int GetCountOfMaterial(string name)
        {
            //establich connection to db
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT count FROM materials WHERE name = @name";
            using var cmd = new MySqlCommand(sql, con); //perform this new command which is sql and do it in the connnect established.

            cmd.Parameters.AddWithValue("@name", name);

            //creates a instance of our command result that can be read in C#.
            using MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            //go through the readbale data and do this for each entry
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            //close the connection
            con.Close();

            Console.WriteLine("Current Count of " + name + ": " + count);
            //return the final results after adding each readable row
            return count;
        }


        /*public static int TotalMaterialCount()
        {
            //establich connection to db
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            //Setup Query
            string sql = "SELECT SUM(count) FROM `materials`";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", name);

            //creates a instance of our command result that can be read in C#.
            using MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            //go through the readbale data and do this for each entry
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            //close the connection
            con.Close();

            Console.WriteLine("Current Count of " + name + ": " + count);
            //return the final results after adding each readable row
            return count;
        }*/


        /*-------------------------------------------------------------------------------------
        //Ticket List
        -------------------------------------------------------------------------------------*/
        /*-------------------------------------------------------------------------------------
        //Get All Tickets
        -------------------------------------------------------------------------------------*/
        public static List<Ticket> GetAllTickets()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT * FROM tickets";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            var results = new List<Ticket>();

            while (reader.Read())
            {
                var ticket = new Ticket(reader.GetInt32(0))
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Department = reader.GetString(2),
                    Description = reader.GetString(3),
                    Status = reader.GetString(4)
                };
                results.Add(ticket);
            }
            return results;
        }
        /*-------------------------------------------------------------------------------------
        //Add New Ticket
        -------------------------------------------------------------------------------------*/
        public static void NewTicket(string title, string department, string description, string status)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "INSERT INTO `tickets`(`title`, `department`, `description`, `status`) VALUES(@title, @department, @description, @status);";
            Console.WriteLine(sql);
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@status", status);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        /*-------------------------------------------------------------------------------------
        //Edit Ticket
        -------------------------------------------------------------------------------------*/

        /*public static void EditTicket(string title, string department, string description, string status)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();
            string sql = "INSERT INTO `tickets`(`title`, `department`, `description`, `status`) VALUES(@title, @department, @description, @status);";
            Console.WriteLine(sql);
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }*/


        /*-------------------------------------------------------------------------------------
        //Delete Ticket
        -------------------------------------------------------------------------------------*/
        public static void DeleteTicket(int id)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "DELETE FROM `tickets` WHERE `id`=@id";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

    }
}
