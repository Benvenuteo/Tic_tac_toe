using System.Collections.Generic;
using TicTacToe.AI;
using TicTacToe.Game;
using TicTacToe.Players;

namespace TicTacToe.Controllers
{
    public interface IGameController
    {
        void StartNewGame();
        void MakeMove(int position);

        /// <summary>
        /// Przełącza tryb gry (z komputerem lub z drugim graczem).
        /// </summary>
        /// <param name="vsComputer">true = z komputerem, false = z drugim graczem</param>
        /// <param name="difficulty">Poziom trudności AI (opcjonalne)</param>
        void SwitchMode(bool vsComputer, DifficultyLevel? difficulty = null);

        void RestartGame();

        /// <summary>
        /// Ustawia drugiego gracza (dla dynamicznej zmiany AI).
        /// </summary>
        /// <param name="player">Nowy gracz 2</param>
        void SetPlayer2(IPlayer player);

        IReadOnlyList<IPlayer> Players { get; }
        IGameState GameState { get; }
    }
}
