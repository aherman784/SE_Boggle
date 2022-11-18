namespace BoggleAPI
{
    public class Dice : IDice
    {
        String[] sides = new String[6];
        String facingLetter;

        public Dice(String[] sides)
        {
            Array.Copy(sides, this.sides, 6);

            roll();
        }

        public void roll()
        {
            Random rnd = new Random();

            facingLetter = sides[rnd.Next(6)];
        }

        public String getLetter()
        {
            return facingLetter;
        }
    }
}