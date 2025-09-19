using System;

namespace TicTacToe.Game
{
    public class TicTacToeState : IGameState
    {
        public const int PLAYER_X = 1;
        public const int PLAYER_O = -1;
        public const int EMPTY = 0;
        public const int ONGOING = -10;
        public const int DRAW = 0;

        public int[,] Board { get; private set; } = new int[3, 3];
        public int CurrentPlayer { get; set; } = PLAYER_X;
        public int MoveCount { get; private set; } = 0;
        public bool IsGameOver { get; set; } = false;

        public TicTacToeState()
        {
            ResetBoard();
        }

        public bool IsValidMove(int position)
        {
            if (position < 0 || position >= 9) return false;
            int row = position / 3;
            int col = position % 3;
            return Board[row, col] == EMPTY;
        }

        public bool MakeMove(int position, int player)
        {
            if (!IsValidMove(position)) return false;

            int row = position / 3;
            int col = position % 3;
            Board[row, col] = player;
            MoveCount++;
            return true;
        }

        public void UndoMove(int position)
        {
            if (position < 0 || position >= 9) return;
            int row = position / 3;
            int col = position % 3;
            if (Board[row, col] != EMPTY)
            {
                Board[row, col] = EMPTY;
                MoveCount--;
            }
        }

        public void ResetBoard()
        {
            Array.Clear(Board, 0, Board.Length);
            MoveCount = 0;
            IsGameOver = false;
            CurrentPlayer = PLAYER_X;
        }
    }
}
