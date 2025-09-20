using System;
using System.Windows.Forms;
using TicTacToe.AI;
using TicTacToe.Controllers;
using TicTacToe.Display;
using TicTacToe.Game;
using TicTacToe.Scoring;

namespace TicTacToe
{
    public partial class TicTacToeBoard : Form
    {
        private IGameController _gameController;
        private FormDisplayManager _displayManager;
        private Button[] _gameButtons;
        private bool _isVsComputer = false;

        public TicTacToeBoard()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            _gameButtons = new Button[9];
            _gameButtons[0] = btn1;
            _gameButtons[1] = btn2;
            _gameButtons[2] = btn3;
            _gameButtons[3] = btn4;
            _gameButtons[4] = btn5;
            _gameButtons[5] = btn6;
            _gameButtons[6] = btn7;
            _gameButtons[7] = btn8;
            _gameButtons[8] = btn9;

            var gameState = new TicTacToeState();
            var gameLogic = new TicTacToeLogic();
            var scoreManager = new ScoreManager();
            _displayManager = new FormDisplayManager(this, _gameButtons, wynikX, wynikO, labelRuch);

            _gameController = new GameController(gameState, gameLogic, scoreManager, _displayManager);

            for (int i = 0; i < _gameButtons.Length; i++)
            {
                int position = i;
                _gameButtons[i].Click += (sender, e) => HandleBoardButtonClick(position);
            }

            SetupDefaultUI();
        }

        private void SetupDefaultUI()
        {
            // Wyłączenie przycisków na start
            foreach (Button btn in _gameButtons)
            {
                btn.Enabled = false;
            }
            btnRestartuj.Enabled = false;

            // Domyślne wartości
            wynikX.Text = "0";
            wynikO.Text = "0";
            labelRuch.Text = "X";

            // Domyślnie ukryj przyciski trudności
            HideDifficultyButtons();

            // Włącz przyciski trybu
            Btn_kolega.Enabled = true;
            Btn_komputer.Enabled = true;
        }

        private void HandleBoardButtonClick(int position)
        {
            if (_gameController == null)
                return;

            if (_gameController.IsGameOver)
                return;

            if (_gameButtons != null && position >= 0 && position < _gameButtons.Length)
            {
                Button button = _gameButtons[position];
                if (button == null || !button.Enabled)
                    return;
            }

            _gameController.MakeMove(position);

            UpdateUIAfterMove();
        }

        private void UpdateUIAfterMove()
        {
            // Aktualizacja planszy i etykiety
            _displayManager.UpdateBoard(_gameController.GameState);

            int currentPlayer = _gameController.GameState.CurrentPlayer;
            if (currentPlayer == TicTacToeState.PLAYER_X)
            {
                labelRuch.Text = "X";
            }
            else
            {
                labelRuch.Text = "O";
            }

        }

        // ========== EVENT HANDLERY PRZYCISKÓW ==========

        private void Btn_kolega_Click(object sender, EventArgs e)
        {
            _isVsComputer = false;
            _gameController.SwitchMode(false);
            UpdateModeButtons(true);
            btnRestartuj.Enabled = true;
            btnRestartuj.PerformClick();
            HideDifficultyButtons();
        }

        private void Btn_komputer_Click(object sender, EventArgs e)
        {
            _isVsComputer = true;
            _gameController.SwitchMode(true, DifficultyLevel.Impossible); // Domyślnie najtrudniejszy
            UpdateModeButtons(false);
            btnRestartuj.Enabled = true;
            btnRestartuj.PerformClick();
            ShowDifficultyButtons();
        }

        // ========== PRZYCISKI POZIOMÓW TRUDNOŚCI ==========

        private void Btn_easy_Click(object sender, EventArgs e)
        {
            _isVsComputer = true;
            _gameController.SwitchMode(true, DifficultyLevel.Easy);
            UpdateModeButtons(false);
            btnRestartuj.PerformClick();
        }

        private void Btn_medium_Click(object sender, EventArgs e)
        {
            _isVsComputer = true;
            _gameController.SwitchMode(true, DifficultyLevel.Medium);
            UpdateModeButtons(false);
            btnRestartuj.PerformClick();
        }

        private void Btn_hard_Click(object sender, EventArgs e)
        {
            _isVsComputer = true;
            _gameController.SwitchMode(true, DifficultyLevel.Hard);
            UpdateModeButtons(false);
            btnRestartuj.PerformClick();
        }

        private void Btn_impossible_Click(object sender, EventArgs e)
        {
            _isVsComputer = true;
            _gameController.SwitchMode(true, DifficultyLevel.Impossible);
            UpdateModeButtons(false);
            btnRestartuj.PerformClick();
        }

        private void btnRestartuj_Click(object sender, EventArgs e)
        {
            _gameController.RestartGame();
            UpdateUIAfterMove();

            labelRuch.Text = "X";

        }

        private void UpdateModeButtons(bool isFriendMode)
        {
            Btn_kolega.Enabled = !isFriendMode;
            Btn_komputer.Enabled = isFriendMode;
            btnRestartuj.Enabled = true;
        }

        private void ShowDifficultyButtons()
        {
            btnEasy.Visible = true;
            btnMedium.Visible = true;
            btnHard.Visible = true;
            btnImpossible.Visible = true;
        }

        private void HideDifficultyButtons()
        {
            btnEasy.Visible = false;
            btnMedium.Visible = false;
            btnHard.Visible = false;
            btnImpossible.Visible = false;
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(0);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(1);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(2);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(3);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(4);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(5);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(6);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(7);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            HandleBoardButtonClick(8);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kółko i Krzyżyk";
            SetupDefaultUI();
        }
    }
}