namespace TheInventory.Models
{
    public class Material
    {
        //Fields
        public string Name { get; set; } = string.Empty;
        public string MaterialType { get; set; } = string.Empty;
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
        public Material(int newCount)
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
            Console.WriteLine("Material has been destroyed");
        }
    }
}
