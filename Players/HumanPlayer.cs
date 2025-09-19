using System.Windows.Forms;
using TicTacToe.Display;
using TicTacToe.Game;

namespace TicTacToe.Players
{
    public class HumanPlayer : IPlayer
    {
        private readonly IDisplayManager _displayManager;
        private readonly Button[] _buttons;

        public string Symbol => PlayerValue == TicTacToeState.PLAYER_X ? "X" : "O";
        public int PlayerValue { get; }
        public string Name { get; }

        public HumanPlayer(int playerValue, string name, IDisplayManager displayManager, Button[] buttons)
        {
            PlayerValue = playerValue;
            Name = name;
            _displayManager = displayManager;
            _buttons = buttons;
        }

        public int GetMove(IGameState state)
        {
            return -1;
        }
    }
}
