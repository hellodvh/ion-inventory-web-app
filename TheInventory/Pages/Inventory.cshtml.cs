using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheInventory.Models;

namespace TheInventory.Pages
{
    public class InventoryModel : PageModel
    {
        public List<Material> allMaterials = new List<Material>();

        public List<Part> allParts = new List<Part>();
        public void OnGet()
        {
            //Create an instance of our Inventory Class for the Materials
            allMaterials = new Inventory().Materials;

            //Create an instance of our Inventory Class for the Materials
            allParts = new Inventory().Parts;
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
