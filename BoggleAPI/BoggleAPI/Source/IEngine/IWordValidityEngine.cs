namespace BoggleAPI.Source.IEngine
{
    public interface IWordValidityEngine
    {
        public bool IsWordValid(string wordGuessed, int playerId);
        public bool IsWordOnBoard(string wordGuessed);
        public bool IsWordCorrectLength(string wordGuessed);
    }
}
