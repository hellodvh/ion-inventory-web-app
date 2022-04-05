using TheInventory.Services;

namespace TheInventory.Models
{
    public class TicketBook
    {
        public List<Ticket> Tickets = new List<Ticket>();
        public TicketBook()
        {
            Tickets = Database.GetAllTickets();
        }

        public void OnPostDelete(int id)
        {
        }
    }
}
