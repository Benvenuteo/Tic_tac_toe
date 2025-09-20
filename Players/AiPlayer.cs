using TicTacToe.AI;
using TicTacToe.Game;

namespace TicTacToe.Players
{
    public class AiPlayer : IPlayer
    {
        private readonly IEvaluator _evaluator;
        private readonly IGameState _gameState;
        private readonly IGameLogic _gameLogic;

        public string Symbol => PlayerValue == TicTacToeState.PLAYER_X ? "X" : "O";
        public int PlayerValue { get; }
        public string Name => $"AI ({_evaluator.AlgorithmName}) - {_evaluator.Difficulty}";

        /// <summary>
        /// Konstruktor z określonym poziomem trudności.
        /// </summary>
        public AiPlayer(int playerValue, IGameState gameState, IGameLogic gameLogic,
            DifficultyLevel difficulty = DifficultyLevel.Impossible)
        {
            PlayerValue = playerValue;
            _gameState = gameState;
            _gameLogic = gameLogic;
            _evaluator = EvaluatorFactory.CreateEvaluator(difficulty);
        }

        public int GetMove(IGameState state)
        {
            return _evaluator.FindBestMove(state, PlayerValue, _gameLogic);
        }

    }
}
