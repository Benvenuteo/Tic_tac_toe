using System.Windows.Forms;
using TicTacToe.Game;

namespace TicTacToe.Display
{
    public interface IDisplayManager
    {
        void UpdateBoard(IGameState state);
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void UpdateScore(int playerXScore, int playerOScore);
        void UpdateTurnIndicator(int currentPlayer);
        void DisableButtons();
        void EnableButtons();
        void ClearBoard();
    }
}
