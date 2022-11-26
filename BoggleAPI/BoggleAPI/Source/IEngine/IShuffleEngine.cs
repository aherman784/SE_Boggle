namespace BoggleAPI
{
    interface IShuffleEngine
    {
        public String[,] GetBoard();
        public void SetNewBoard();
    }
}