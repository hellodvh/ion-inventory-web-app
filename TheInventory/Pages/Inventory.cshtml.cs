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

        public int MaterialTotal = 0; 
        public int PartTotal = 0; 
        public int VehicleTotal = 0;

        public string MaterialData = "";
        public string PartData = "";
        public string VehicleData = "";

        public void OnGet()
        {
            allMaterials = new Inventory().Materials;
            allParts = new Inventory().Parts;
            allVehicles = new Inventory().Vehicles;

            MaterialTotal = Services.Database.TotalSumMaterialCount();
            PartTotal = Services.Database.TotalSumPartCount();
            VehicleTotal = Services.Database.TotalSumVehicleCount();
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
