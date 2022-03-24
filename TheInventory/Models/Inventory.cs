using TheInventory.Services;

namespace TheInventory.Models
{
    public class Inventory
    {
        //material variable that is called from the frontend.
        public List<Material> Materials = new List<Material>();

        //constructor: fetch the database
        public Inventory()
        {
            Materials = Database.GetAllMaterials();
        }

        public void UpdateCount(string name, int count)
        {
            Database.UpdateMaterialCount(name, count);
        }

        //Function to Get Count
        public int GetCount(string name)
        {
            foreach(var material in Materials)//Searching for specific material
            {
                if (material.Name == name)
                {
                    return material.Count;//return the count of that material   
                } 
            }
            return -1;
        }
    }
}
