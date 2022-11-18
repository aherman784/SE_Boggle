namespace BoggleAPI
{
    public class Board : IBoard
    {
        Dice[,] dice = new Dice[4,4];

        public Board()
        {
            dice[0, 0] = new Dice(new String[] { "R", "I", "F", "O", "B", "X" });
            dice[0, 1] = new Dice(new String[] { "I", "F", "E", "H", "E", "Y" });
            dice[0, 2] = new Dice(new String[] { "D", "E", "N", "O", "W", "S" });
            dice[0, 3] = new Dice(new String[] { "U", "T", "O", "K", "N", "D" }); 
            dice[1, 0] = new Dice(new String[] { "H", "M", "S", "R", "A", "O" });
            dice[1, 1] = new Dice(new String[] { "L", "U", "P", "E", "T", "S" }); 
            dice[1, 2] = new Dice(new String[] { "A", "C", "I", "T", "O", "A" });
            dice[1, 3] = new Dice(new String[] { "Y", "L", "G", "K", "U", "E" }); 
            dice[2, 0] = new Dice(new String[] { "Qu","B", "M", "J", "O", "A" });
            dice[2, 1] = new Dice(new String[] { "E", "H", "I", "S", "P", "N" }); 
            dice[2, 2] = new Dice(new String[] { "V", "E", "T", "I", "G", "N" });
            dice[2, 3] = new Dice(new String[] { "B", "A", "L", "I", "Y", "T" });
            dice[3, 0] = new Dice(new String[] { "E", "Z", "A", "V", "N", "D" });
            dice[3, 1] = new Dice(new String[] { "R", "A", "L", "E", "S", "C" });
            dice[3, 2] = new Dice(new String[] { "U", "W", "I", "L", "R", "G" });
            dice[3, 3] = new Dice(new String[] { "P", "A", "C", "E", "M", "D" });

            shuffle();
        }

        public void shuffle()
        {
            for (int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    dice[i, j].roll();
                }
            }
        }

        public Dice[,] getDice()
        {
            return dice;
        }
    }
}