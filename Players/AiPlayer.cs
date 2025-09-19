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

        /// <summary>
        /// Konstruktor z określonym algorytmem.
        /// </summary>
        public AiPlayer(int playerValue, IGameState gameState, IGameLogic gameLogic,
            string algorithmName)
        {
            PlayerValue = playerValue;
            _gameState = gameState;
            _gameLogic = gameLogic;
            _evaluator = EvaluatorFactory.CreateEvaluator(algorithmName);
        }

        /// <summary>
        /// Konstruktor z konkretnym evaluatorem (dla zaawansowanych scenariuszy).
        /// </summary>
        public AiPlayer(int playerValue, IGameState gameState, IGameLogic gameLogic,
            IEvaluator evaluator)
        {
            PlayerValue = playerValue;
            _gameState = gameState;
            _gameLogic = gameLogic;
            _evaluator = evaluator ?? throw new System.ArgumentNullException(nameof(evaluator));
        }

        public int GetMove(IGameState state)
        {
            return _evaluator.FindBestMove(state, PlayerValue, _gameLogic);
        }

        /// <summary>
        /// Zwraca aktualnie używany evaluator.
        /// </summary>
        public IEvaluator CurrentEvaluator => _evaluator;

        /// <summary>
        /// Zwraca poziom trudności AI.
        /// </summary>
        public DifficultyLevel Difficulty => _evaluator.Difficulty;

        /// <summary>
        /// Zwraca nazwę algorytmu.
        /// </summary>
        public string AlgorithmName => _evaluator.AlgorithmName;
    }
}
