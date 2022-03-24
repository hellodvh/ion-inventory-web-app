using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheInventory.Models;

namespace TheInventory.Pages
{
    public class TicketModel : PageModel
    {
        public List<Ticket> allTickets = new List<Ticket>();
        public void OnGet()
        {
            //Call Database Get Function and display on website
            allTickets = new TicketBook().Tickets;
        }

        public IActionResult OnPostDelete(int id)
        {
            //Call Database Delete Function and reload the page
            Services.Database.DeleteTicket(id);
            return RedirectToAction("./Ticket");
        }
    }
}
