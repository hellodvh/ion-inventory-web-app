using TheInventory.Interfaces;

namespace TheInventory.Models
{
    public class Coal : Block, Flammable
    {
        public Coal(int newCount) : base(newCount)
        {
        }

        public override void place()
        {
            Console.WriteLine("Coal has been placed");
        }

        public void Burn()
        {
            Console.WriteLine("Coal is burning!");
        }
    }
}
