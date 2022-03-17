using MySql.Data.MySqlClient;

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

    }
}
