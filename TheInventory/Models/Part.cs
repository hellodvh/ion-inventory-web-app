namespace TheInventory.Models
{
    public class Part
    {
        //Fields
        public string Name { get; set; } = string.Empty;
        public string PartType { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        private int count;
        public int Count 
        { 
            get 
            { 
                //Function
                return count; 
            }
            set
            {
                //Function
                if (value > 0)
                    count = value;
                else
                    count = 0;
            }
        }

        //Constructor
        public Part(int newCount)
        {
            count = newCount;
        }

        //Method
        public virtual void place()
        {
            Console.WriteLine($"{Name} has been placed.");
        }

        public void destroy()
        {
            count = 0;
            Console.WriteLine("Material has been destroyed");
        }
    }
}
