using TheInventory.Interfaces;

namespace TheInventory.Models
{
    public class VehicleRecipe : Craftable
    {
        public VehicleRecipe(int newCount)
        {
            count = newCount;
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VehicleCategory { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        private int count;
        public int Count { get { return count; } }
        public List<string> Ingredients { get; set; } = new List<string>();
        public bool IsCraftable()
        {
            var map = new Dictionary<string, int>();

            foreach (var vehicle in Ingredients)
            {
                if (vehicle != "")
                {
                    int count;
                    if (map.TryGetValue(vehicle, out count))
                    {
                        map[vehicle] += 1;
                    }
                    else
                    {
                        map.Add(vehicle, 1);
                    }
                }
            }

            bool result = true;
            var inventory = new Inventory();

            foreach (var pair in map)
            {
                if (pair.Value > inventory.GetCount(pair.Key))
                {
                    return false;
                }
            }
            return result;
        }
    }
}
