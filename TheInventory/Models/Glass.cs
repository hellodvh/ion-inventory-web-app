namespace TheInventory.Models
{
    public class Glass : Block
    {
        //Constructor
        public Glass(int newCount) : base(newCount)
        {

        }

        public override void place()
        {
            Console.WriteLine("Glass has been placed.");
        }
    }
}
