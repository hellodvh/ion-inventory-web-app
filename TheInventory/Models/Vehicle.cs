namespace TheInventory.Models
{
    public class Vehicle
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VehicleCategory { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        /*public string Verify { get; set; } = string.Empty;*/

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

        public Vehicle(int newCount)
        {
            count = newCount;
        }
    }
}
