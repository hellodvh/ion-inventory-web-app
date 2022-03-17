using TheInventory.Interfaces;

namespace TheInventory.Models
{
    public class Sand : Block, Meltable
    {
        public Sand(int newCount) : base(newCount)
        {
        }

        public override void place()
        {
            Console.WriteLine("Sand has been placed.");
        }

        public Block Melt()
        {
            Console.WriteLine("Sand is melting into Glass");
            Count--;
            return new Glass(1);
        }
    }
}
