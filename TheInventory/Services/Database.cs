using MySql.Data.MySqlClient;
using System.Text;
using TheInventory.Models;

namespace TheInventory.Services
{
    public class Database
    {
        private static string serverConfiguration = @"server=localhost;userid=root;password=;database=iondb;";
        public static string GetVersion()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            return con.ServerVersion;
        }

        internal static object TotalMaterialCount()
        {
            throw new NotImplementedException();
        }

        /*-------------------------------------------------------------------------------------
        //Get All the Materials
        -------------------------------------------------------------------------------------*/
        public static List<Material> GetAllMaterials()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT * FROM materials";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();
            var results = new List<Material>();

            while(reader.Read())
            {
                var material = new Material(reader.GetInt32(4))
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1),
                    MaterialCategory = reader.GetString(2),
                    MaterialType = reader.GetString(3),
                    Count = reader.GetInt32(4),
                    ImageUrl = reader.GetString(5)
                };
                results.Add(material);
            }
            return results;
        }

        /*-------------------------------------------------------------------------------------
        //Get All the PARTS
        -------------------------------------------------------------------------------------*/
        public static List<Part> GetAllParts()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT * FROM parts";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();
            var results = new List<Part>();

            while (reader.Read())
            {
                var part = new Part(reader.GetInt32(4))
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1),
                    PartCategory = reader.GetString(2),
                    PartType = reader.GetString(3),
                    Count = reader.GetInt32(4),
                    ImageUrl = reader.GetString(5)
                };
                results.Add(part);
            }
            return results;
        }

        /*-------------------------------------------------------------------------------------
        //Get All the VEHICLES
        -------------------------------------------------------------------------------------*/
        public static List<Vehicle> GetAllVehicles()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT * FROM vehicles";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();
            var results = new List<Vehicle>();

            while (reader.Read())
            {
                var vehicle = new Vehicle(reader.GetInt32(4))
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1),
                    VehicleCategory = reader.GetString(2),
                    VehicleType = reader.GetString(3),
                    Count = reader.GetInt32(4),
                    ImageUrl = reader.GetString(5)
                };
                results.Add(vehicle);
            }
            return results;
        }

        /*-------------------------------------------------------------------------------------
        //Update the count of materials
        -------------------------------------------------------------------------------------*/
        public static void UpdateMaterialCount(string name, int newCount)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "UPDATE `materials` SET `count`= @count WHERE `name` = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@count", newCount);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        /*-------------------------------------------------------------------------------------
        //Update the count of parts UpdateVehicleCount
        -------------------------------------------------------------------------------------*/
        public static void UpdatePartCount(string name, int newCount)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "UPDATE `parts` SET `count`= @count WHERE `name` = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@count", newCount);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        /*-------------------------------------------------------------------------------------
        //Update the count of Vehicle
        -------------------------------------------------------------------------------------*/
        public static void UpdateVehicleCount(string name, int newCount)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "UPDATE `vehicles` SET `count`= @count WHERE `name` = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@count", newCount);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        /*-------------------------------------------------------------------------------------
        //Get List of All PART Recipes
        -------------------------------------------------------------------------------------*/
        public static List<PartRecipe> GetAllPartRecipes()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT * FROM parts";
            using var cmd = new MySqlCommand(sql, con); 

            using MySqlDataReader reader = cmd.ExecuteReader();

            var results = new List<PartRecipe>();

            while (reader.Read())
            {
                var partrecipe = new PartRecipe(reader.GetInt32(4))
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1),
                    PartCategory = reader.GetString(2),
                    PartType = reader.GetString(3),
                };

                var ingredients = new List<string>();
                ingredients.Add(reader.GetString(6)); // ingredient 1
                ingredients.Add(reader.GetString(7)); // ingredient 2
                ingredients.Add(reader.GetString(8)); // ingredient 3
                ingredients.Add(reader.GetString(9)); // ingredient 4
                ingredients.Add(reader.GetString(10)); // ingredient 5
                ingredients.Add(reader.GetString(11)); // ingredient 6
                ingredients.Add(reader.GetString(12)); // ingredient 7
                ingredients.Add(reader.GetString(13)); // ingredient 8
                ingredients.Add(reader.GetString(14)); // ingredient 9
                ingredients.Add(reader.GetString(15)); // ingredient 10

                partrecipe.Ingredients = ingredients;

                results.Add(partrecipe);
            }
            con.Close();
;            return results;
        }

        /*-------------------------------------------------------------------------------------
        //Get List of All Vehicle Recipes
        -------------------------------------------------------------------------------------*/
        public static List<VehicleRecipe> GetAllVehicleRecipes()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT * FROM vehicles";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            var results = new List<VehicleRecipe>();

            while (reader.Read())
            {
                var vehiclerecipe = new VehicleRecipe(reader.GetInt32(4))
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1),
                };

                var ingredients = new List<string>();
                ingredients.Add(reader.GetString(6)); // ingredient 1
                ingredients.Add(reader.GetString(7)); // ingredient 2
                ingredients.Add(reader.GetString(8)); // ingredient 3
                ingredients.Add(reader.GetString(9)); // ingredient 4
                ingredients.Add(reader.GetString(10)); // ingredient 5
                ingredients.Add(reader.GetString(11)); // ingredient 6
                ingredients.Add(reader.GetString(12)); // ingredient 7
                ingredients.Add(reader.GetString(13)); // ingredient 8
                ingredients.Add(reader.GetString(14)); // ingredient 9
                ingredients.Add(reader.GetString(15)); // ingredient 10

                vehiclerecipe.Ingredients = ingredients;

                results.Add(vehiclerecipe);
            }
            con.Close();

            return results;
        }

        /*-------------------------------------------------------------------------------------
        //Craft PART Recipe
        -------------------------------------------------------------------------------------*/
        public static bool CraftPartRecipe(string nameId, int newCount, List<string> ingredients, string verify)
        {
            if(CheckVerifyCode(nameId, verify))
            {
                UpdateMaterialCountAfterCraft(ingredients);

                using var con = new MySqlConnection(serverConfiguration);
                con.Open();

                string sql = "UPDATE `parts` SET `count`= @count WHERE `name` = @name";

                using var cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", nameId);
                cmd.Parameters.AddWithValue("@count", newCount);

                cmd.Prepare();
                cmd.ExecuteNonQuery();

                return true;
            }
            else
            {
                return false;      
            }  
        }

        /*-------------------------------------------------------------------------------------
        //Craft VEHICLE Recipe
        -------------------------------------------------------------------------------------*/
        public static bool CraftVehicleRecipe(string nameId, int newCount, List<string> ingredients, string verify)
        {
            if (CheckVehicleVerifyCode(nameId, verify))
            {
                UpdatePartCountAfterCraft(ingredients);
                using var con = new MySqlConnection(serverConfiguration);
                con.Open();

                string sql = "UPDATE `vehicles` SET `count`= @count WHERE `name` = @name";
                using var cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", nameId);
                cmd.Parameters.AddWithValue("@count", newCount);

                cmd.Prepare();
                cmd.ExecuteNonQuery();

                return true;
            }
            else
            {
                return false;
            }
        }

        /*-------------------------------------------------------------------------------------
        //Check Verify Code - PARTS
        -------------------------------------------------------------------------------------*/
        private static bool CheckVerifyCode(string nameId, string verifyInput)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            var sql = "SELECT verifycode FROM parts WHERE name = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", nameId);

            using MySqlDataReader reader = cmd.ExecuteReader();

            var databaseVerifyCode = "";

            while (reader.Read())
            {
                databaseVerifyCode = reader.GetString(0);
            }
            con.Close();

            byte[]? data = Encoding.ASCII.GetBytes(verifyInput);
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
        //Check Verify Code - VEHICLES
        -------------------------------------------------------------------------------------*/
        private static bool CheckVehicleVerifyCode(string nameId, string verifyInput)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            var sql = "SELECT verifycode FROM vehicles WHERE name = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", nameId);

            using MySqlDataReader reader = cmd.ExecuteReader();

            var databaseVerifyCode = "";

            while (reader.Read())
            {
                databaseVerifyCode = reader.GetString(0);
            }
            con.Close();

            byte[]? data = Encoding.ASCII.GetBytes(verifyInput);
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
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            foreach (string material in ingredients)
            {
                if (material != "")
                {
                    Console.WriteLine("Current Ingredient Loop: " + material);
                    int currentCount = GetCountOfMaterial(material);

                    string sql = "UPDATE `materials` SET `count`= @count WHERE `name` = @name";
                    using var cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@name", material);
                    cmd.Parameters.AddWithValue("@count", currentCount - 1);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*-------------------------------------------------------------------------------------
        //Get COUNT Of Material
        -------------------------------------------------------------------------------------*/
        public static int GetCountOfMaterial(string name)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT count FROM materials WHERE name = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", name);

            using MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            con.Close();

            Console.WriteLine("Current Count of " + name + ": " + count);
            return count;
        }

        /*-------------------------------------------------------------------------------------
        //Update PART Count After Crating
        -------------------------------------------------------------------------------------*/
        public static void UpdatePartCountAfterCraft(List<string> ingredients)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            foreach (string part in ingredients)
            {
                if (part != "")
                {
                    Console.WriteLine("Current Ingredient Loop: " + part);
                    int currentCount = GetCountOfPart(part);

                    string sql = "UPDATE `parts` SET `count`= @count WHERE `name` = @name";
                    using var cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@name", part);
                    cmd.Parameters.AddWithValue("@count", currentCount - 1);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*-------------------------------------------------------------------------------------
        //Get COUNT of PART
        -------------------------------------------------------------------------------------*/
        public static int GetCountOfPart(string name)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT count FROM parts WHERE name = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", name);

            using MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            con.Close();

            Console.WriteLine("Current Count of " + name + ": " + count);
            return count;
        }

        /*-------------------------------------------------------------------------------------
        //Update VEHICLE Count After Crating
        -------------------------------------------------------------------------------------*/
        public static void UpdateVehicleCountAfterCraft(List<string> ingredients)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            foreach (string vehicle in ingredients)
            {
                if (vehicle != "")
                {
                    Console.WriteLine("Current Ingredient Loop: " + vehicle);
                    int currentCount = GetCountOfVehicle(vehicle);

                    string sql = "UPDATE `vehicles` SET `count`= @count WHERE `name` = @name";
                    using var cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@name", vehicle);
                    cmd.Parameters.AddWithValue("@count", currentCount - 1);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        /*-------------------------------------------------------------------------------------
        //Get COUNT of VEHICLE
        -------------------------------------------------------------------------------------*/
        public static int GetCountOfVehicle(string name)
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT count FROM vehicles WHERE name = @name";
            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@name", name);

            using MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            con.Close();

            Console.WriteLine("Current Count of " + name + ": " + count);
            return count;
        }

        /*-------------------------------------------------------------------------------------
        //Get Count Of TOTAL MATERIAL       
        "SELECT SUM(count) AS TotalMaterialCount FROM `materials`"; 
        "SELECT SUM(count) FROM `materials`";
        -------------------------------------------------------------------------------------*/
        public static int TotalSumMaterialCount()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT SUM(count) FROM `materials`";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            int totalMaterials = 0;

            while (reader.Read())
            {
                totalMaterials = reader.GetInt32(0);
            }
            con.Close();
            
            Console.WriteLine("Current Total Count of " + totalMaterials);
            return totalMaterials;
        }

        /*-------------------------------------------------------------------------------------
        //Get Count Of TOTAL PART
        -------------------------------------------------------------------------------------*/
        public static int TotalSumPartCount()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT SUM(count) FROM `parts`";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            int totalParts = 0;

            while (reader.Read())
            {
                totalParts = reader.GetInt32(0);
            }
            con.Close();

            Console.WriteLine("Current Total Count of " + totalParts);
            return totalParts;
        }

        /*-------------------------------------------------------------------------------------
        //Get Count Of TOTAL PART
        -------------------------------------------------------------------------------------*/
        public static int TotalSumVehicleCount()
        {
            using var con = new MySqlConnection(serverConfiguration);
            con.Open();

            string sql = "SELECT SUM(count) FROM `vehicles`";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            int totalVehicles = 0;

            while (reader.Read())
            {
                totalVehicles = reader.GetInt32(0);
            }
            con.Close();

            Console.WriteLine("Current Total Count of " + totalVehicles);
            return totalVehicles;
        }

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
            con.Close();
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
