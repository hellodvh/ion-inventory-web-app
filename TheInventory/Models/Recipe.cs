using TheInventory.Interfaces;

namespace TheInventory.Models
{
    public class Recipe : Craftable
    {
        //recipe constructor to set the count
        public Recipe(int newCount)
        {
            count = newCount;
        }

        //properties
        public string Name { get; set; } = string.Empty;
        public string RecipeType { get; set; } = string.Empty;
        private int count;
        public int Count { get { return count; } }

        //TODO: Ingredients property
        public List<string> Ingredients { get; set; } = new List<string>();
        //interface method
        public bool IsCraftable()
        {
            //check if we have all the required resources
            //setup empty dictionary which will contain the item and the amount we need.
            //STEP 1: Create Dictionary of all the ingredients & how many of each
            var map = new Dictionary<string, int>();

            foreach (var material in Ingredients)
            {
                //loop through all ingredients and add them to dictionary
                if (material != "") //check if null
                {
                    int count;
                    if (map.TryGetValue(material, out count))// have we added this ingredient before?
                    {   //increment the count
                        map[material] += 1;
                    }
                    else//if we haven't added the ingredient to the dictionary.
                    {   //add the block to it
                        map.Add(material, 1);
                    }
                }
            }
            //default response is that it is craftable
            bool result = true;
            //go create our inventory that we check our values in

            //STEP 2: check if we have the required amount of each ingredient.
            var inventory = new Inventory();

            //loop through our ingredient dictionary
            foreach (var pair in map)
            {
                if (pair.Value > inventory.GetCount(pair.Key))//if the amount that we need is less than the amount we have
                {
                    return false;//set craftable to false.
                }
            }
            //return if it is craftable or not
            return result;
        }
    }
}
