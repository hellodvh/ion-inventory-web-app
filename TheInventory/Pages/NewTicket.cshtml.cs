using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheInventory.Models;
using TheInventory.Services;

namespace TheInventory.Pages
{
    public class NewTicketModel : PageModel
    {
        private List<Ticket> allTickets = new List<Ticket>();

        public void OnGet()
        {
            allTickets = Database.GetAllTickets();
        }

        public IActionResult OnPostAdd(string title, string department, string description, string status)
        {
            Database.NewTicket(title, department, description, status);
            return RedirectToPage("./Ticket");
        }
    }
}
