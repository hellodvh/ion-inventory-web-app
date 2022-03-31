namespace TheInventory.Models
{
    public class PartRecipe
    {
        public PartRecipe(int newCount)
        {
            count = newCount;
        }

        public string Name { get; set; } = string.Empty;
        public string PartType { get; set; } = string.Empty;
        private int count;
        public int Count { get { return count; } }
        public List<string> Ingredients { get; set; } = new List<string>();
        public bool IsCraftable()
        {
            var map = new Dictionary<string, int>();

            foreach (var part in Ingredients)
            {
                if (part != "")
                {
                    int count;
                    if (map.TryGetValue(part, out count))
                    {
                        map[part] += 1;
                    }
                    else
                    {
                        map.Add(part, 1);
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
