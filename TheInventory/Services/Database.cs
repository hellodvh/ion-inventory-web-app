using MySql.Data.MySqlClient;
using TheInventory.Models;

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

        /*
        //Get All the Materials (blocks)
        */
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

        /*
        //Update the count of materials
        */
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

        /*
        //Get List of All Recipes
        */

        /*
        //Craft a Recipe
        */

        /*
        //Update Material Count After Craft
        */

        /*
        //Get Count of Material
        */

    }
}
