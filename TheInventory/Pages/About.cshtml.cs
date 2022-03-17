using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheInventory.Pages
{
    public class AboutModel : PageModel
    {
        //Database Version / Connection Test
        public string Message = "";
        public void OnGet()
        {
            //Database Version / Connection Test
            Message = Services.Database.GetVersion();
        }
    }
}
