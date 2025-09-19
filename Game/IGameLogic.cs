namespace TicTacToe.Game
{
    public interface IGameLogic
    {
        int CheckWinner(IGameState state);
        bool IsValidMove(IGameState state, int position);
        bool IsGameOver(IGameState state);
    }
}
