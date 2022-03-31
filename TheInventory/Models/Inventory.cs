using TheInventory.Services;

namespace TheInventory.Models
{
    public class Inventory
    {
        //material variable that is called from the frontend.
        public List<Material> Materials = new List<Material>();

        //PARTS
        /*public List<Part> Parts = new List<Part>();*/

        //constructor: fetch the database
        public Inventory()
        {
            //MATERIALS
            Materials = Database.GetAllMaterials();

            //PARTS
            /*Parts = Database.GetAllParts();*/
        }

        public void UpdateCount(string name, int count)
        {
            //MATERIALS
            Database.UpdateMaterialCount(name, count);

            //PARTS
            /*Database.UpdatePartCount(name, count);*/
        }

        //Function to Get Count
        public int GetCount(string name)
        {
            //MATERIAL
            foreach(var material in Materials)//Searching for specific material
            {
                if (material.Name == name)
                {
                    return material.Count;//return the count of that material   
                } 
            }
            return -1;

            //PARTS
            /*foreach (var part in Parts)
            {
                if (part.Name == name)
                {
                    return part.Count;  
                }
            }
            return -1;*/
        }
    }
}
