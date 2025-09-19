using System;

namespace TicTacToe.AI
{
    public static class EvaluatorFactory
    {
        /// <summary>
        /// Tworzy evaluator na podstawie poziomu trudności.
        /// </summary>
        public static IEvaluator CreateEvaluator(DifficultyLevel difficulty)
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    return new RandomEvaluator();
                case DifficultyLevel.Medium:
                    return new HeuristicEvaluator();
                case DifficultyLevel.Hard:
                    return new MinimaxEvaluator();
                case DifficultyLevel.Impossible:
                    return new AlphaBetaEvaluator();
                default:
                    throw new ArgumentException($"Nieznany poziom trudności: {difficulty}", nameof(difficulty));
            }
        }

        /// <summary>
        /// Tworzy evaluator na podstawie nazwy algorytmu.
        /// </summary>
        public static IEvaluator CreateEvaluator(string algorithmName)
        {
            if (string.IsNullOrWhiteSpace(algorithmName))
                throw new ArgumentException("Nazwa algorytmu nie może być pusta", nameof(algorithmName));

            string normalizedName = algorithmName.Trim().ToLowerInvariant();

            switch (normalizedName)
            {
                case "random":
                case "easy":
                    return new RandomEvaluator();

                case "heuristic":
                case "medium":
                    return new HeuristicEvaluator();

                case "minimax":
                case "hard":
                    return new MinimaxEvaluator();

                case "alphabeta":
                case "alpha-beta":
                case "impossible":
                    return new AlphaBetaEvaluator();

                default:
                    // Próba parsowania nazwy jako poziom trudności
                    if (Enum.TryParse<DifficultyLevel>(normalizedName, true, out var difficulty))
                    {
                        return CreateEvaluator(difficulty);
                    }

                    // Domyślnie AlphaBeta (najlepszy)
                    return new AlphaBetaEvaluator();
            }
        }

    }
}
