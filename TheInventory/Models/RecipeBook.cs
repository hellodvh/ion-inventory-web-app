using TheInventory.Services;

namespace TheInventory.Models
{
    public class RecipeBook
    {
        //recipe variable that is called from the frontend
        public List<Recipe> Recipes = new List<Recipe>();

        //constructor
        public RecipeBook()
        {
            Recipes = Database.GetAllRecipes();
        }

        public bool CraftRecipe(string name, int count, List<string> ingredient, string verify)
        {
            Console.WriteLine(ingredient[0]);
            //Call the database function
            return Database.CraftRecipe(name, count, ingredient, verify);
        }
    }
}
