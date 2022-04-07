using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheInventory.Models;

namespace TheInventory.Pages
{
    public class GarageModel : PageModel
    {

        public List<Vehicle> allVehicles = new List<Vehicle>();

        public int VehicleTotal = 0;
        public void OnGet()
        {
            allVehicles = new Inventory().Vehicles;

            VehicleTotal = Services.Database.TotalSumVehicleCount();
        }
    }
}
