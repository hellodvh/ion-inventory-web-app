using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TheInventory.Models;

namespace TheInventory.Pages
{
    public class AssemblyModel : PageModel
    {
        public List<PartRecipe> allParts = new List<PartRecipe>();
        public List<VehicleRecipe> allVehicles = new List<VehicleRecipe>();
        public string Message { get; set; } = string.Empty;
        public bool MessageSuccess { get; set; } = false;

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Verify { get; set; } = "";
        public void OnGet(string message = "", bool success = true)
        {
            allParts = new PartRecipeBook().Parts;
            allVehicles = new VehicleRecipeBook().Vehicles;

            Message = message;
            MessageSuccess = success;
        }

        public IActionResult OnPostCraft(string name, int count, List<string> ingredient, string verify)
        {
            var success = new VehicleRecipeBook().CraftVehicleRecipe(name, count + 1, ingredient, verify);

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
            new Inventory().UpdateCount(name, count);

            return RedirectToPage("./Assembly");
        }
    }
}
