namespace TheInventory.Models
{
    public class Ticket
    {

        //Fields
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public string Status { get; set; } = string.Empty;

        private int count;

        public int Count
        {
            get 
            { 
                return count; 
            }
            set
            {
                if (value > 0)
                    count = value;
                else
                    count = 0;
            }
        }

        //Constructor
        public Ticket(int newCount)
        {
            count = newCount;
        }
    }
}
