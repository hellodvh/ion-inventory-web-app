using TheInventory.Services;

namespace TheInventory.Models
{
    public class VehicleRecipeBook
    {
        public List<VehicleRecipe> Vehicles = new List<VehicleRecipe>();

        public VehicleRecipeBook()
        {
            Vehicles = Database.GetAllVehicleRecipes();
        }

        public bool CraftVehicleRecipe(string name, int count, List<string> ingredient, string verify)
        {
            Console.WriteLine(ingredient[0]);
            return Database.CraftVehicleRecipe(name, count, ingredient, verify);
        }
    }
}
