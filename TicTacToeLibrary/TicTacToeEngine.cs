using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class TicTacToeEngine
    {          

        TicTacToeEngine()
        {
            Status = GameStatus.PlayerOPlays;
        }

        public GameStatus Status { get; private set; }

        public String Board()
        {
            //TODO: 
            return "";
        }

        public bool ChooseCell(int cell)
        {
            //TODO: 
            return true;
        }

        public void Reset()
        {
            //TODO:
        }  

    }    

    public enum GameStatus
    {
        PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins
    }   

}
