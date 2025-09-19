using System;
using System.Collections.Generic;
using System.Diagnostics;
using TicTacToe.Game;

namespace TicTacToe.AI
{
    public class AlphaBetaEvaluator : IEvaluator
    {
        public int FindBestMove(IGameState state, int player, IGameLogic gameLogic)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AlphaBeta(state, 0, int.MinValue, int.MaxValue, player, true, gameLogic);
            stopwatch.Stop();

            result.TimeTakenMs = stopwatch.ElapsedMilliseconds;
            return result.BestMove;
        }

        public int EvaluatePosition(IGameState state, int player, IGameLogic gameLogic)
        {
            return AlphaBeta(state, 0, int.MinValue, int.MaxValue, player, true, gameLogic).Score;
        }

        public int MaxDepth => 9;
        public string AlgorithmName => "Alpha-Beta Pruning";
        public DifficultyLevel Difficulty => DifficultyLevel.Impossible;

        private EvaluationResult AlphaBeta(IGameState state, int depth, int alpha, int beta,
            int player, bool maximizing, IGameLogic gameLogic)
        {
            int winner = gameLogic.CheckWinner(state);

            // Warunki terminalne
            if (winner != TicTacToeState.ONGOING)
            {
                int score = CalculateTerminalScore(winner, depth, player);
                return new EvaluationResult(score);
            }

            if (depth >= MaxDepth)
            {
                return new EvaluationResult(0);
            }

            EvaluationResult best = new EvaluationResult
            {
                Score = maximizing ? int.MinValue : int.MaxValue
            };

            var moves = GetSortedMoves(state, player, maximizing, gameLogic);

            foreach (int pos in moves)
            {
                int currentPlayer = maximizing ? player : -player;
                state.MakeMove(pos, currentPlayer);

                EvaluationResult result = AlphaBeta(state, depth + 1, alpha, beta,
                    player, !maximizing, gameLogic);
                state.UndoMove(pos);

                best.NodesVisited++;

                if (maximizing)
                {
                    if (result.Score > best.Score)
                    {
                        best.Score = result.Score;
                        if (depth == 0) best.BestMove = pos;
                    }
                    alpha = Math.Max(alpha, result.Score);
                }
                else
                {
                    if (result.Score < best.Score)
                    {
                        best.Score = result.Score;
                        if (depth == 0) best.BestMove = pos;
                    }
                    beta = Math.Min(beta, result.Score);
                }

                if (alpha >= beta)
                {
                    break;
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
                case TicTacToeState.DRAW:
                    return 0;
                default:
                    return 0;
            }
        }

        private IEnumerable<int> GetSortedMoves(IGameState state, int player, bool maximizing, IGameLogic gameLogic)
        {
            var moves = new List<int>();

            // Centrum
            if (state.IsValidMove(4)) moves.Add(4);

            // Narożniki
            int[] corners = { 0, 2, 6, 8 };
            foreach (int corner in corners)
            {
                if (state.IsValidMove(corner)) moves.Add(corner);
            }

            // Boki
            int[] sides = { 1, 3, 5, 7 };
            foreach (int side in sides)
            {
                if (state.IsValidMove(side)) moves.Add(side);
            }

            return moves;
        }
    }
}
