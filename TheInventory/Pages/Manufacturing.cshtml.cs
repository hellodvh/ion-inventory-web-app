using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheInventory.Models;

namespace TheInventory.Pages
{
    public class ManufacturingModel : PageModel
    {
        public List<Recipe> allRecipes = new List<Recipe>();
        public string Message { get; set; } = string.Empty;
        public void OnGet(string message = "")
        {
            allRecipes = new RecipeBook().Recipes;

            Message = message;
        }

        public IActionResult OnPostCraft(string name, int count, List<string> ingredient)
        {
            //Call the function nd pass the name, updated count and ingredient
            new RecipeBook().CraftRecipe(name, count + 1, ingredient);

            return Redirect($"./Manufacturing?message={name} has been crafted");
        }
    }
}
