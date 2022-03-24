using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheInventory.Models;

namespace TheInventory.Pages
{
    public class InventoryModel : PageModel
    {
        public List<Material> allMaterials = new List<Material>();

        public void OnGet()
        {
            //Create an instance of our Inventory Class for the Materials
            allMaterials = new Inventory().Materials;
        }

        //On Post Update function to update the database.
        public IActionResult OnPostUpdate(string name, int count)
        {
            Console.WriteLine($"{name} should change to {count}");
            new Inventory().UpdateCount(name, count);

            //Redirect back to normal get
            return RedirectToPage("./Inventory");
        }    
    }
}
