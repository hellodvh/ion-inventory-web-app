namespace TheInventory.Models
{
    public class Part
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PartCategory { get; set; } = string.Empty;
        public string PartType { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

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
        public Part(int newCount)
        {
            count = newCount;
        }
    }
}
