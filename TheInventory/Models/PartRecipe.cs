using TheInventory.Interfaces;

namespace TheInventory.Models
{
    public class PartRecipe : Craftable
    {
        public PartRecipe(int newCount)
        {
            count = newCount;
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PartCategory { get; set; } = string.Empty;
        public string PartType { get; set; } = string.Empty;
        public string RecipeType { get; set; } = string.Empty;
        private int count;
        public int Count { get { return count; } }

        public List<string> Ingredients { get; set; } = new List<string>();

        public bool IsCraftable()
        {
            var map = new Dictionary<string, int>();

            foreach (var material in Ingredients)
            {
                if (material != "")
                {
                    int count;
                    if (map.TryGetValue(material, out count))
                    {  
                        map[material] += 1;
                    }
                    else
                    { 
                        map.Add(material, 1);
                    }
                }
            }

            bool result = true;

            var inventory = new Inventory();

            foreach (var pair in map)
            {
                if (pair.Value > inventory.GetMaterialCount(pair.Key))
                {
                    return false;
                }
            }
            return result;
        }
    }
}