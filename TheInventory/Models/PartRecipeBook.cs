using TheInventory.Services;

namespace TheInventory.Models
{
    public class PartRecipeBook
    {
        //recipe variable that is called from the frontend
        public List<PartRecipe> Parts = new List<PartRecipe>();

        //constructor
        public PartRecipeBook()
        {
            Parts = Database.GetAllPartRecipes();
        }

        public bool CraftPartRecipe(string name, int count, List<string> ingredient, string verify)
        {
            Console.WriteLine(ingredient[0]);
            //Call the database function
            return Database.CraftPartRecipe(name, count, ingredient, verify);
        }
    }
}
