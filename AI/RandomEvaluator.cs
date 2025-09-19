using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Game;

namespace TicTacToe.AI
{
    public class RandomEvaluator : IEvaluator
    {
        private readonly Random _random = new Random();

        public int FindBestMove(IGameState state, int player, IGameLogic gameLogic)
        {
            var validMoves = GetValidMoves(state).ToList();
            if (!validMoves.Any()) return -1;

            return validMoves[_random.Next(validMoves.Count)];
        }

        public int EvaluatePosition(IGameState state, int player, IGameLogic gameLogic)
        {
            int winner = gameLogic.CheckWinner(state);

            switch (winner)
            {
                case TicTacToeState.PLAYER_X:
                    return player == TicTacToeState.PLAYER_X ? 10 : -10;
                case TicTacToeState.PLAYER_O:
                    return player == TicTacToeState.PLAYER_O ? 10 : -10;
                case TicTacToeState.DRAW:
                    return 0;
                default:
                    return _random.Next(-5, 6);
            }
        }

        public int MaxDepth => 0;

        public string AlgorithmName => "Random";

        public DifficultyLevel Difficulty => DifficultyLevel.Easy;

        private IEnumerable<int> GetValidMoves(IGameState state)
        {
            for (int i = 0; i < 9; i++)
            {
                if (state.IsValidMove(i))
                    yield return i;
            }
        }
    }
}
