using System;

namespace TicTacToeLibrary
{
    public class TicTacToeEngine
    {
        private IGameBoard gameboard;
        private LoopList<Player> playerList;

        public TicTacToeEngine() : this(3, new LoopList<Player> { new Player('X'), new Player('O') }) { }

        public TicTacToeEngine(int boardSize, LoopList<Player> players)
        {
            this.playerList = players;
            Status = GameStatus.PlayerPlays;
            gameboard = new MatrixGameBoard(boardSize);
        }

        public GameStatus Status { get; private set; }

        public String Board()
        {
            return gameboard.ToString();
        }

        public bool ChooseCell(int cell)
        {
            bool replaced = false;
            if (Status.Equals(GameStatus.PlayerPlays))
            {
                char symbol = GetCurrentPlayer().GetSymbol();
                replaced = gameboard.ReplaceNumber(cell, symbol);

                if (replaced)
                {
                    if (gameboard.HasWon(symbol))
                        Status = GameStatus.PlayerWon;
                    else
                        playerList.GetNext();
                }
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
            Status = GameStatus.PlayerPlays;
            playerList.Reset();
            gameboard.Reset();
        }

        public bool GameFinished()
        {
            return Status.ToString().ToUpper().Contains("WON") || gameboard.GetNumbersLeft() <= 0;
        }

        public Player GetCurrentPlayer()
        {
            return playerList.GetCurrent();
        }

    }    

    public enum GameStatus
    {
        PlayerPlays, Equal, PlayerWon
    }   

}
