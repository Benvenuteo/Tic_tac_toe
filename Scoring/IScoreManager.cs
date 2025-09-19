namespace TicTacToe.Scoring
{
    public interface IScoreManager
    {
        int PlayerXScore { get; }
        int PlayerOScore { get; }
        void AddPointToPlayerX();
        void AddPointToPlayerO();
        void ResetScores();
    }
}
