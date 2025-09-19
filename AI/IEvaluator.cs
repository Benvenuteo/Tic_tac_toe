using TicTacToe.Game;

namespace TicTacToe.AI
{
    public interface IEvaluator
    {
        /// <summary>
        /// Znajduje najlepszy ruch dla podanego gracza w bieżącym stanie gry.
        /// </summary>
        /// <param name="state">Bieżący stan gry</param>
        /// <param name="player">Gracz, którego ruch oceniamy</param>
        /// <param name="gameLogic">Logika gry do sprawdzania wygranych</param>
        /// <returns>Indeks najlepszego pola do zagrania (0-8) lub -1 jeśli brak ruchów</returns>
        int FindBestMove(IGameState state, int player, IGameLogic gameLogic);

        /// <summary>
        /// Ocenia wartość danej pozycji planszy dla określonego gracza.
        /// </summary>
        /// <param name="state">Stan gry do oceny</param>
        /// <param name="player">Gracz, dla którego oceniamy pozycję</param>
        /// <param name="gameLogic">Logika gry</param>
        /// <returns>Wartość pozycji (wyższa = lepsza dla gracza)</returns>
        int EvaluatePosition(IGameState state, int player, IGameLogic gameLogic);

        /// <summary>
        /// Maksymalna głębokość przeszukiwania drzewa gry.
        /// </summary>
        int MaxDepth { get; }

        /// <summary>
        /// Nazwa algorytmu dla debugowania i UI.
        /// </summary>
        string AlgorithmName { get; }

        /// <summary>
        /// Poziom trudności (Easy, Medium, Hard, Impossible).
        /// </summary>
        DifficultyLevel Difficulty { get; }
    }

    /// <summary>
    /// Poziomy trudności AI.
    /// </summary>
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard,
        Impossible
    }

    /// <summary>
    /// Klasa pomocnicza do przechowywania wyników oceny.
    /// </summary>
    public class EvaluationResult
    {
        public int Score { get; set; }
        public int BestMove { get; set; } = -1;
        public int NodesVisited { get; set; } = 0;
        public double TimeTakenMs { get; set; } = 0;

        public EvaluationResult(int score, int bestMove = -1)
        {
            Score = score;
            BestMove = bestMove;
        }
        public EvaluationResult()
        {
        }
    }
}

