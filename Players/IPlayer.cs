using TicTacToe.Game;

namespace TicTacToe.Players
{
    public interface IPlayer
    {
        string Symbol { get; }
        int PlayerValue { get; }
        int GetMove(IGameState state);
        string Name { get; }
    }
}
