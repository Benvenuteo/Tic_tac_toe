namespace TicTacToe.Game
{
    public class TicTacToeLogic : IGameLogic
    {
        private readonly int[][] _winningCombinations = {
        new[] {0, 1, 2}, new[] {3, 4, 5}, new[] {6, 7, 8}, // Wiersze
        new[] {0, 3, 6}, new[] {1, 4, 7}, new[] {2, 5, 8}, // Kolumny
        new[] {0, 4, 8}, new[] {2, 4, 6} // Przekątne
    };

        public int CheckWinner(IGameState state)
        {
            // Sprawdzenie kombinacji wygrywających
            foreach (var combination in _winningCombinations)
            {
                int firstPos = combination[0];
                int secondPos = combination[1];
                int thirdPos = combination[2];

                int row1 = firstPos / 3;
                int col1 = firstPos % 3;
                int row2 = secondPos / 3;
                int col2 = secondPos % 3;
                int row3 = thirdPos / 3;
                int col3 = thirdPos % 3;

                if (state.Board[row1, col1] != TicTacToeState.EMPTY &&
                    state.Board[row1, col1] == state.Board[row2, col2] &&
                    state.Board[row2, col2] == state.Board[row3, col3])
                {
                    return state.Board[row1, col1];
                }
            }

            // Sprawdzenie remisu
            if (state.MoveCount == 9) return TicTacToeState.DRAW;

            return TicTacToeState.ONGOING;
        }

        public bool IsValidMove(IGameState state, int position)
        {
            return state.IsValidMove(position);
        }

        public bool IsGameOver(IGameState state)
        {
            return state.IsGameOver || CheckWinner(state) != TicTacToeState.ONGOING;
        }
    }
}