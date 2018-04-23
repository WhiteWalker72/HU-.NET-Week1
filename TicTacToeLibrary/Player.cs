using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class Player
    {

        private readonly char symbol;

        public Player(char symbol)
        {
            this.symbol = symbol;
        }

        public char GetSymbol() => symbol;

    }
}
