using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheInventory.Models;


namespace TheInventory.Pages
{
    public class ManufacturingModel : PageModel
    {
        public List<Material> allMaterials = new List<Material>(); 
        public List<PartRecipe> allParts = new List<PartRecipe>();
        public string Message { get; set; } = string.Empty;
        public bool MessageSuccess { get; set; } = false;

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Verify { get; set; } = "";
        public void OnGet(string message = "", bool success = true)
        {
            allMaterials = new Inventory().Materials;
            allParts = new PartRecipeBook().Parts;

            Message = message;
            MessageSuccess = success;
        }

        public IActionResult OnPostCraft(string name, int count, List<string> ingredient, string verify)
        {
            var success = new PartRecipeBook().CraftPartRecipe(name, count + 1, ingredient, verify);

            if (success)
            {
                return Redirect($"./Manufacturing?success=true&message= {name} has been manufactured.");
            }
            else
            {
                return Redirect($"./Manufacturing?success=false&message=    Verification Code is invalid!   Please enter a valid passcode.");
            }   
        }
        public IActionResult OnPostUpdate(string name, int count)
        {
            new Inventory().UpdateCount(name, count);

            return RedirectToPage("./Manufacturing");
        }
    }
}
