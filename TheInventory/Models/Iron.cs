using TheInventory.Interfaces;

namespace TheInventory.Models
{
    public class Iron : Material, Meltable
    {
        public Iron(int newCount) : base(newCount)
        {

        }

        public override void place()
        {
            Console.WriteLine("Iron has been placed");
        }

        public void Melt()
        {
            Console.WriteLine("Ïron is melting");
        }
    }
}
