using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TheInventory.Models;


namespace TheInventory.Pages
{
    public class InventoryModel : PageModel
    {
        public List<Material> allMaterials = new List<Material>();

        public List<Part> allParts = new List<Part>();

        public List<Vehicle> allVehicles = new List<Vehicle>();

        public string totalMaterials = string.Empty;
        public string MaterialData = ""; //graphs
        public string PartData = "";

        public void OnGet()
        {
            //Create an instance of our Inventory Class for the Materials
            allMaterials = new Inventory().Materials;
            allParts = new Inventory().Parts;
            allVehicles = new Inventory().Vehicles;

            MaterialData = JsonConvert.SerializeObject(allMaterials); //graphs
            PartData = JsonConvert.SerializeObject(allParts); //graphs
        }

        /*//On Post Update function to update the database.
        public IActionResult OnPostUpdate(string name, int count)
        {
            Console.WriteLine($"{name} should change to {count}");
            new Inventory().UpdateCount(name, count);

            //Redirect back to normal get
            return RedirectToPage("./Inventory");
        }*/
    }
}
