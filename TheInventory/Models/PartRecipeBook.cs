using TheInventory.Services;

namespace TheInventory.Models
{
    public class PartRecipeBook
    {
        public List<Part> Parts = new List<Part>();

        public PartRecipeBook()
        {
            /*Parts = Database.GetAllPartRecipes();*/
        }

        public bool CraftRecipe(string name, int count, List<string> ingredient, string verify)
        {
            Console.WriteLine(ingredient[0]);
            return Database.CraftRecipe(name, count, ingredient, verify);
        }
    }
}
