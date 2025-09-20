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

        private bool _isRestarting = false;
        private System.Windows.Forms.Timer _restartTimer;

        public IReadOnlyList<IPlayer> Players => new[] { _player1, _player2 };
        public IGameState GameState => _gameState;
        public bool IsGameOver => _gameState.IsGameOver || _isRestarting;
        public IPlayer CurrentPlayer => _gameState.CurrentPlayer == TicTacToeState.PLAYER_X ? _player1 : _player2;


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
            _isRestarting = false;
            StopRestartTimer();

            // Reset stanu gry
            _gameState.ResetBoard();

            // Czyszczenie UI
            _displayManager.ClearBoard();

            // Aktualizacja UI
            _displayManager.UpdateTurnIndicator(_gameState.CurrentPlayer);
            _displayManager.UpdateBoard(_gameState);

        }


        public void MakeMove(int position)
        {
            if (_isRestarting)
                return;

            if (_gameState.IsGameOver)
                return;

            if (!_gameState.IsValidMove(position))
                return;

            if (_gameState.MakeMove(position, _gameState.CurrentPlayer))
            {
                HandleMoveResult(position);
            }
        }

        private void HandleMoveResult(int position)
        {
            if (_isRestarting)
                return;


            _displayManager.UpdateBoard(_gameState);

            int winner = _gameLogic.CheckWinner(_gameState);
            if (winner != TicTacToeState.ONGOING)
            {
                HandleGameEnd(winner);
                return;
            }

            _gameState.CurrentPlayer = -_gameState.CurrentPlayer;
            _displayManager.UpdateTurnIndicator(_gameState.CurrentPlayer);

            if (_isVsComputer && _gameState.CurrentPlayer == TicTacToeState.PLAYER_O)
            {
                System.Windows.Forms.Timer aiTimer = new System.Windows.Forms.Timer();
                aiTimer.Interval = 200;
                aiTimer.Tick += (sender, e) =>
                {
                    aiTimer.Stop();
                    aiTimer.Dispose();
                    MakeAiMove();
                };
                aiTimer.Start();
            }
        }

        private void MakeAiMove()
        {
            if (_isRestarting || _gameState.IsGameOver || !_isVsComputer)
                return;

            int aiMove = _player2.GetMove(_gameState);

            if (aiMove != -1 && _gameState.MakeMove(aiMove, _gameState.CurrentPlayer))
            {
                HandleMoveResult(aiMove);
            }
        }

        private void HandleGameEnd(int winner)
        {
            _isRestarting = true;
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
                    // Błąd - wznów grę
                    _isRestarting = false;
                    _gameState.IsGameOver = false;
                    _displayManager.EnableButtons();
                    return;
            }

            _displayManager.ShowMessage(message, title, icon);

            System.Windows.Forms.Timer restartTimer = new System.Windows.Forms.Timer();
            restartTimer.Interval = 100;
            restartTimer.Tick += (sender, e) =>
            {
                restartTimer.Stop();
                restartTimer.Dispose();

                // WZNÓW GRĘ
                _isRestarting = false;
                _gameState.IsGameOver = false;

                StartNewRound();
            };
            restartTimer.Start();
        }

        private void StartNewRound()
        {
            _gameState.ResetBoard();

            // Czyszczenie i włączenie
            _displayManager.ClearBoard();

            // UI
            _displayManager.UpdateTurnIndicator(_gameState.CurrentPlayer);
            _displayManager.UpdateBoard(_gameState);

        }

        /// <summary>
        /// Zatrzymanie timera restartu
        /// </summary>
        private void StopRestartTimer()
        {
            if (_restartTimer != null)
            {
                _restartTimer.Stop();
                _restartTimer.Dispose();
                _restartTimer = null;
            }
        }

        public void SwitchMode(bool vsComputer, DifficultyLevel? difficulty = null)
        {
            // Zresetuj flagi
            _isRestarting = false;
            StopRestartTimer();

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

            // Nowa gra
            _gameState.IsGameOver = false;
            StartNewRound();
        }

        public void SetPlayer2(IPlayer player)
        {
            _isRestarting = false;
            StopRestartTimer();

            if (player == null)
                throw new ArgumentNullException(nameof(player));

            _player2 = player;
            _isVsComputer = player is AiPlayer;
        }

        public void RestartGame()
        {
            _isRestarting = false;
            StopRestartTimer();
            _gameState.IsGameOver = false;

            _scoreManager.ResetScores();
            _displayManager.UpdateScore(0, 0);
            StartNewGame();
        }
    }
}