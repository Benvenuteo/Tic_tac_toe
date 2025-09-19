using System.Diagnostics;
using TicTacToe.Game;

namespace TicTacToe.AI
{
    public class MinimaxEvaluator : IEvaluator
    {
        public int FindBestMove(IGameState state, int player, IGameLogic gameLogic)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = Minimax(state, 0, player, true, gameLogic);
            stopwatch.Stop();

            result.TimeTakenMs = stopwatch.ElapsedMilliseconds;
            return result.BestMove;
        }

        public int EvaluatePosition(IGameState state, int player, IGameLogic gameLogic)
        {
            return Minimax(state, 0, player, true, gameLogic).Score;
        }

        public int MaxDepth => 6;

        public string AlgorithmName => "Minimax";

        public DifficultyLevel Difficulty => DifficultyLevel.Hard;

        private EvaluationResult Minimax(IGameState state, int depth, int player,
            bool maximizing, IGameLogic gameLogic)
        {
            int winner = gameLogic.CheckWinner(state);

            // Warunki terminalne
            if (winner != TicTacToeState.ONGOING)
            {
                int score = CalculateTerminalScore(winner, depth, player);
                return new EvaluationResult(score);
            }

            // Ograniczenie głębokości
            if (depth >= MaxDepth)
            {
                return new EvaluationResult(EvaluateHeuristic(state, player, gameLogic));
            }

            EvaluationResult best = new EvaluationResult
            {
                Score = maximizing ? int.MinValue : int.MaxValue
            };

            // Przeglądanie wszystkich ruchów
            for (int pos = 0; pos < 9; pos++)
            {
                if (!state.IsValidMove(pos)) continue;

                int currentPlayer = maximizing ? player : -player;
                state.MakeMove(pos, currentPlayer);

                EvaluationResult result = Minimax(state, depth + 1, player, !maximizing, gameLogic);
                state.UndoMove(pos);

                best.NodesVisited++;

                if (maximizing)
                {
                    if (result.Score > best.Score)
                    {
                        best.Score = result.Score;
                        if (depth == 0) best.BestMove = pos;
                    }
                }
                else
                {
                    if (result.Score < best.Score)
                    {
                        best.Score = result.Score;
                        if (depth == 0) best.BestMove = pos;
                    }
                }
            }

            return best;
        }

        private int CalculateTerminalScore(int winner, int depth, int aiPlayer)
        {
            switch (winner)
            {
                case TicTacToeState.PLAYER_X:
                    return aiPlayer == TicTacToeState.PLAYER_X ? 10 - depth : depth - 10;
                case TicTacToeState.PLAYER_O:
                    return aiPlayer == TicTacToeState.PLAYER_O ? 10 - depth : depth - 10;
                case TicTacToeState.DRAW: return 0;
                default: return 0;
            }
        }

        private int EvaluateHeuristic(IGameState state, int player, IGameLogic gameLogic)
        {
            int score = 0;

            // Bonus za centrum
            if (state.Board[1, 1] == player) score += 3;

            // Kara za centrum przeciwnika
            if (state.Board[1, 1] == -player) score -= 3;

            // Analiza narożników
            int[] corners = { 0, 2, 6, 8 };
            foreach (int corner in corners)
            {
                int row = corner / 3;
                int col = corner % 3;
                if (state.Board[row, col] == player) score += 2;
                if (state.Board[row, col] == -player) score -= 2;
            }

            return score;
        }
    }
}
