using System.Collections.Generic;
using System.Linq;
using TicTacToe.Game;

namespace TicTacToe.AI
{
    public class HeuristicEvaluator : IEvaluator
    {
        private readonly int[][] _winningCombinations = {
            new[] {0, 1, 2}, new[] {3, 4, 5}, new[] {6, 7, 8}, // Wiersze
            new[] {0, 3, 6}, new[] {1, 4, 7}, new[] {2, 5, 8}, // Kolumny
            new[] {0, 4, 8}, new[] {2, 4, 6} // Przekątne
        };

        public int FindBestMove(IGameState state, int player, IGameLogic gameLogic)
        {
            var validMoves = GetValidMoves(state).ToList();
            if (!validMoves.Any()) return -1;

            // Szukamy ruchu wygrywającego
            foreach (int move in validMoves)
            {
                state.MakeMove(move, player);
                if (gameLogic.CheckWinner(state) == player)
                {
                    state.UndoMove(move);
                    return move;
                }
                state.UndoMove(move);
            }

            // Szukamy ruchu blokującego
            int opponent = -player;
            foreach (int move in validMoves)
            {
                state.MakeMove(move, opponent);
                if (gameLogic.CheckWinner(state) == opponent)
                {
                    state.UndoMove(move);
                    return move;
                }
                state.UndoMove(move);
            }

            // Heurystyczna ocena pozostałych ruchów
            var bestMove = validMoves
                .Select(move => new { Move = move, Score = EvaluateMove(move, state, player, gameLogic) })
                .OrderByDescending(x => x.Score)
                .First();

            return bestMove.Move;
        }

        public int EvaluatePosition(IGameState state, int player, IGameLogic gameLogic)
        {
            int winner = gameLogic.CheckWinner(state);
            if (winner != TicTacToeState.ONGOING)
            {
                return winner == player ? 100 : -100;
            }

            int score = 0;

            // Bonus za kontrolę centrum
            if (state.Board[1, 1] == player) score += 5;

            // Analiza wszystkich kombinacji
            foreach (var combination in _winningCombinations)
            {
                score += EvaluateCombination(state, combination, player);
            }

            return score;
        }

        public int MaxDepth => 2;

        public string AlgorithmName => "Heuristic";

        public DifficultyLevel Difficulty => DifficultyLevel.Medium;

        private IEnumerable<int> GetValidMoves(IGameState state)
        {
            for (int i = 0; i < 9; i++)
            {
                if (state.IsValidMove(i))
                    yield return i;
            }
        }

        private int EvaluateMove(int move, IGameState state, int player, IGameLogic gameLogic)
        {
            state.MakeMove(move, player);
            int score = EvaluatePosition(state, player, gameLogic);
            state.UndoMove(move);
            return score;
        }

        private int EvaluateCombination(IGameState state, int[] positions, int player)
        {
            int playerCount = 0;
            int opponentCount = 0;
            int emptyCount = 0;

            foreach (int pos in positions)
            {
                int row = pos / 3;
                int col = pos % 3;
                int cell = state.Board[row, col];

                if (cell == player) playerCount++;
                else if (cell == -player) opponentCount++;
                else emptyCount++;
            }

            // Wygrana w zasięgu
            if (playerCount == 2 && emptyCount == 1) return 50;
            if (opponentCount == 2 && emptyCount == 1) return -40; // Musi blokować

            // Dwie w linii
            if (playerCount == 2) return 10;
            if (opponentCount == 2) return -8;

            // Jedna w linii
            if (playerCount == 1 && emptyCount == 2) return 2;
            if (opponentCount == 1 && emptyCount == 2) return -1;

            return 0;
        }
    }
}
