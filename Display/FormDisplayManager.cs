using System;
using System.Windows.Forms;
using TicTacToe.Game;

namespace TicTacToe.Display
{
    public class FormDisplayManager : IDisplayManager
    {
        private readonly TicTacToeBoard _form;
        private readonly Button[] _buttons;
        private readonly Label _scoreXLabel;
        private readonly Label _scoreOLabel;
        private readonly Label _turnLabel;

        public FormDisplayManager(TicTacToeBoard form, Button[] buttons,
            Label scoreXLabel, Label scoreOLabel, Label turnLabel)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
            _scoreXLabel = scoreXLabel ?? throw new ArgumentNullException(nameof(scoreXLabel));
            _scoreOLabel = scoreOLabel ?? throw new ArgumentNullException(nameof(scoreOLabel));
            _turnLabel = turnLabel ?? throw new ArgumentNullException(nameof(turnLabel));
        }

        public void UpdateBoard(IGameState state)
        {
            for (int i = 0; i < 9; i++)
            {
                int row = i / 3;
                int col = i % 3;
                string symbol;

                switch (state.Board[row, col])
                {
                    case TicTacToeState.PLAYER_X:
                        symbol = "X";
                        break;
                    case TicTacToeState.PLAYER_O:
                        symbol = "O";
                        break;
                    default:
                        symbol = "";
                        break;
                }
                _buttons[i].Text = symbol;
            }
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(_form, message, title, MessageBoxButtons.OK, icon);
        }

        public void UpdateScore(int playerXScore, int playerOScore)
        {
            _scoreXLabel.Text = playerXScore.ToString();
            _scoreOLabel.Text = playerOScore.ToString();
        }

        public void UpdateTurnIndicator(int currentPlayer)
        {
            _turnLabel.Text = currentPlayer == TicTacToeState.PLAYER_X ? "X" : "O";
        }

        public void DisableButtons()
        {
            foreach (var button in _buttons)
            {
                button.Enabled = false;
            }
        }

        public void EnableButtons()
        {
            foreach (var button in _buttons)
            {
                button.Enabled = true;
            }
        }

        public void ClearBoard()
        {
            if (_buttons == null || _buttons.Length != 9) return;

            for (int i = 0; i < 9; i++)
            {
                if (_buttons[i] != null)
                {
                    _buttons[i].Enabled = true;
                    _buttons[i].Text = "";
                }
            }
        }
    }
}