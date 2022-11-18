namespace BoggleAPI
{
    interface IBoard
    {
        void shuffle();
        Dice[,] getDice();
    }
}