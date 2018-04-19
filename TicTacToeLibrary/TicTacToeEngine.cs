using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class TicTacToeEngine
    {
        private IGameBoard gameboard;

        public TicTacToeEngine()
        {
            Status = GameStatus.PlayerOPlays;
            gameboard = new MatrixGameBoard();
        }

        public GameStatus Status { get; private set; }

        public String Board()
        {
            return gameboard.ToString();
        }

        public bool ChooseCell(int cell)
        {
            bool replaced = false;
            if (Status.Equals(GameStatus.PlayerOPlays))
            {
                replaced = HandleCellAction(cell, GameStatus.PlayerXPlays, GameStatus.PlayerOWins, 'O');
            }
            else if (Status.Equals(GameStatus.PlayerXPlays))
            {
                replaced = HandleCellAction(cell, GameStatus.PlayerOPlays, GameStatus.PlayerXWins, 'X');
            }
            return replaced;
        }

        private bool HandleCellAction(int cell, GameStatus newStatus, GameStatus winStatus, char playerSymbol)
        {
            bool replaced = gameboard.ReplaceNumber(cell, playerSymbol);
            if (replaced)
            {
                Status = gameboard.HasWon(playerSymbol) ? winStatus : newStatus;
            }
            return replaced;
        }

        public void Reset()
        {
            Status = GameStatus.PlayerOPlays;
            gameboard.Reset();
        }

        public bool GameFinished()
        {
            return Status.ToString().ToUpper().Contains("WINS") || gameboard.GetNumbersLeft() <= 0;
        }
    }    

    public enum GameStatus
    {
        PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins
    }   

}
