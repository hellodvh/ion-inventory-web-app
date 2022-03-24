using TheInventory.Services;

namespace TheInventory.Models
{
    public class Inventory
    {
        //material variable that is called from the frontend.
        public List<Material> Materials = new List<Material>();

        //part variable that is called from the frontend.
        public List<Part> Parts = new List<Part>();

        //constructor: fetch the database
        public Inventory()
        {
            Materials = Database.GetAllMaterials();
            Parts = Database.GetAllParts();
        }

        public void UpdateCount(string name, int count)
        {
            Database.UpdateMaterialCount(name, count);
            Database.UpdatePartCount(name, count);
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
