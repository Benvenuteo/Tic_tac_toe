namespace TicTacToe.Scoring
{
    public class ScoreManager : IScoreManager
    {
        private int _playerXScore = 0;
        private int _playerOScore = 0;

        public int PlayerXScore => _playerXScore;
        public int PlayerOScore => _playerOScore;

        public void AddPointToPlayerX() => _playerXScore++;
        public void AddPointToPlayerO() => _playerOScore++;
        public void ResetScores()
        {
            _playerXScore = 0;
            _playerOScore = 0;
        }
    }
}
