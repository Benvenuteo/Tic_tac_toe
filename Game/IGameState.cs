namespace TicTacToe.Game
{
    public interface IGameState
    {
        bool IsValidMove(int position);
        bool MakeMove(int position, int player);
        void UndoMove(int position);
        void ResetBoard();
        int MoveCount { get; }
        int CurrentPlayer { get; set; }
        bool IsGameOver { get; set; }
        int[,] Board { get; }
    }
}
