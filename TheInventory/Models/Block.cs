namespace TheInventory.Models
{
    public class Block
    {
        //Fields
        public string Name { get; set; } = string.Empty;
        public string BlockType { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        private int count;
        public int Count
        {
            get 
            { 
                //functionality
                return count; 
            }
            set
            {
                //functionality
                if (value > 0)
                    count = value;
                else
                    count = 0;
            }
        }

        //Constructor
        public Block(int newCount)
        {
            count = newCount;
        }
        //Methods
        public virtual void place()
        {
            Console.WriteLine($"{Name} has been placed.");
        }

        public void destroy()
        {
            count = 0;
            Console.WriteLine("Block has been destroyed");
        }

    }
}
