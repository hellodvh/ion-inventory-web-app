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

        public void CraftRecipe(string name, int count, List<string> ingredient)
        {
            Console.WriteLine(ingredient[0]);
            //Call the database function
            Database.CraftRecipe(name, count, ingredient);
        }
    }
}
