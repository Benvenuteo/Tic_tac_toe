using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToe.AI;
using TicTacToe.Display;
using TicTacToe.Game;
using TicTacToe.Players;
using TicTacToe.Scoring;

namespace TicTacToe.Controllers
{
    public class GameController : IGameController
    {
        private readonly IGameState _gameState;
        private readonly IGameLogic _gameLogic;
        private readonly IScoreManager _scoreManager;
        private readonly IDisplayManager _displayManager;

        private IPlayer _player1;
        private IPlayer _player2;
        private bool _isVsComputer = false;
        private System.Windows.Forms.Timer _aiTimer;

        public IReadOnlyList<IPlayer> Players => new[] { _player1, _player2 };
        public IGameState GameState => _gameState;

        public GameController(IGameState gameState, IGameLogic gameLogic,
            IScoreManager scoreManager, IDisplayManager displayManager)
        {
            _gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            _gameLogic = gameLogic ?? throw new ArgumentNullException(nameof(gameLogic));
            _scoreManager = scoreManager ?? throw new ArgumentNullException(nameof(scoreManager));
            _displayManager = displayManager ?? throw new ArgumentNullException(nameof(displayManager));

            InitializeDefaultPlayers();
        }

        private void InitializeDefaultPlayers()
        {
            _player1 = new HumanPlayer(TicTacToeState.PLAYER_X, "Gracz X", _displayManager, null);
            _player2 = new HumanPlayer(TicTacToeState.PLAYER_O, "Gracz O", _displayManager, null);
        }

        public void StartNewGame()
        {
            _gameState.ResetBoard();
            _displayManager.EnableButtons();
            _displayManager.UpdateTurnIndicator(_gameState.CurrentPlayer);
            _displayManager.UpdateBoard(_gameState);
        }

        public void MakeMove(int position)
        {
            // Sprawdź czy gra się nie zakończyła
            if (_gameLogic.IsGameOver(_gameState))
                return;

            // Sprawdź czy pozycja jest prawidłowa
            if (!_gameState.IsValidMove(position))
                return;

            // Wykonaj ruch aktualnego gracza
            if (_gameState.MakeMove(position, _gameState.CurrentPlayer))
            {
                // Obsłuż wynik ruchu
                HandleMoveResult(position);
            }
        }

        private void HandleMoveResult(int position)
        {
            // Aktualizacja UI
            _displayManager.UpdateBoard(_gameState);

            // Sprawdź czy gra się zakończyła
            int winner = _gameLogic.CheckWinner(_gameState);
            if (winner != TicTacToeState.ONGOING)
            {
                HandleGameEnd(winner);
                return;
            }

            // Zmiana gracza
            _gameState.CurrentPlayer = -_gameState.CurrentPlayer;

            // Aktualizacja wskaźnika tury
            _displayManager.UpdateTurnIndicator(_gameState.CurrentPlayer);

            // Automatyczny ruch AI (tylko jeśli to tura gracza O i gramy z komputerem)
            if (_isVsComputer && _gameState.CurrentPlayer == TicTacToeState.PLAYER_O)
            {
                if (_aiTimer != null)
                {
                    _aiTimer.Stop();
                    _aiTimer.Dispose();
                    _aiTimer = null;
                }

                _aiTimer = new System.Windows.Forms.Timer();
                _aiTimer.Interval = 100;
                _aiTimer.Tick += (sender, e) =>
                {
                    _aiTimer.Stop();
                    _aiTimer.Dispose();
                    _aiTimer = null;
                    MakeAiMove();
                };
                _aiTimer.Start();
            }
        }

        private void MakeAiMove()
        {
            if (!_isVsComputer || _gameLogic.IsGameOver(_gameState))
                return;

            int aiMove = _player2.GetMove(_gameState);

            if (aiMove != -1 && _gameState.MakeMove(aiMove, _gameState.CurrentPlayer))
            {
                HandleMoveResult(aiMove);
            }
        }

        private void HandleGameEnd(int winner)
        {
            _gameState.IsGameOver = true;
            _displayManager.DisableButtons();

            string message;
            string title = "Koniec gry";
            MessageBoxIcon icon = MessageBoxIcon.Information;

            switch (winner)
            {
                case TicTacToeState.PLAYER_X:
                    _scoreManager.AddPointToPlayerX();
                    message = "Wygrywa gracz X!";
                    _displayManager.UpdateScore(_scoreManager.PlayerXScore, _scoreManager.PlayerOScore);
                    break;

                case TicTacToeState.PLAYER_O:
                    _scoreManager.AddPointToPlayerO();
                    message = $"Wygrywa {_player2.Name}!";
                    _displayManager.UpdateScore(_scoreManager.PlayerXScore, _scoreManager.PlayerOScore);
                    break;

                case TicTacToeState.DRAW:
                    message = "Remis!";
                    icon = MessageBoxIcon.Warning;
                    break;

                default:
                    return;
            }

            _displayManager.ShowMessage(message, title, icon);

            if (_aiTimer != null)
            {
                _aiTimer.Stop();
                _aiTimer.Dispose();
                _aiTimer = null;
            }

            StartNewRound();

        }

        private void StartNewRound()
        {
            // Reset stanu gry
            if (_aiTimer != null)
            {
                _aiTimer.Stop();
                _aiTimer.Dispose();
                _aiTimer = null;
            }
            _gameState.ResetBoard();
            _gameState.CurrentPlayer = TicTacToeState.PLAYER_X; // Zawsze X zaczyna

            // Włącz przyciski i zaktualizuj UI
            _displayManager.EnableButtons();
            _displayManager.UpdateTurnIndicator(_gameState.CurrentPlayer);
            _displayManager.UpdateBoard(_gameState);
        }

        public void SwitchMode(bool vsComputer, DifficultyLevel? difficulty = null)
        {
            _isVsComputer = vsComputer;

            if (vsComputer)
            {
                var aiDifficulty = difficulty ?? DifficultyLevel.Impossible;
                _player2 = new AiPlayer(TicTacToeState.PLAYER_O, _gameState, _gameLogic, aiDifficulty);
            }
            else
            {
                _player2 = new HumanPlayer(TicTacToeState.PLAYER_O, "Gracz O", _displayManager, null);
            }

            StartNewRound();
        }


        public void SetPlayer2(IPlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            _player2 = player;
            _isVsComputer = player is AiPlayer;
        }

        public void RestartGame()
        {
            _scoreManager.ResetScores();
            _displayManager.UpdateScore(0, 0);
            StartNewRound();
        }
    }
}