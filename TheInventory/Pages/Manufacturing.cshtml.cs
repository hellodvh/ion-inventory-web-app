using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheInventory.Models;

namespace TheInventory.Pages
{
    public class ManufacturingModel : PageModel
    {
        public List<Material> allMaterials = new List<Material>(); 
        public List<Recipe> allRecipes = new List<Recipe>();
        public string Message { get; set; } = string.Empty;
        public bool MessageSuccess { get; set; } = false;
        public void OnGet(string message = "", bool success = true)
        {
            allMaterials = new Inventory().Materials;
            allRecipes = new RecipeBook().Recipes;
            

            Message = message;
            MessageSuccess = success;
        }

        public IActionResult OnPostCraft(string name, int count, List<string> ingredient, string verify)
        {
            //Call the function nd pass the name, updated count and ingredient
            var success = new RecipeBook().CraftRecipe(name, count + 1, ingredient, verify);

            if (success)
            {
                return Redirect($"./Manufacturing?success=true&message={name} has been crafted");
            }
            else
            {
                return Redirect($"./Manufacturing?success=false&message=Code incorrect!");
            }
            
        }

        public IActionResult OnPostUpdate(string name, int count)
        {
            Console.WriteLine($"{name} should change to {count}");
            new Inventory().UpdateCount(name, count);


            //redirect back to normal get
            return RedirectToPage("./Manufacturing");
        }
    }
}
