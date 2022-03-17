using TheInventory.Interfaces;

namespace TheInventory.Models
{
    public class Wood : Block, Flammable, Meltable
    {

        //Constructor
        public Wood(int newCount) : base(newCount)
        {

        }

        public override void place()
        {
            Console.WriteLine("Wood has been placed.");
        }

        public void Burn()
        {
            Count--;
            Console.WriteLine("Wood is burning!");
        }

        public Block Melt()
        {
            Console.WriteLine("Wood is melting into Coal");
            return new Coal(1);
        }

        Block Meltable.Melt()
        {
            throw new NotImplementedException();
        }
    }
}
