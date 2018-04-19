using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    interface IGameBoard
    {
        void Reset();

        bool ReplaceNumber(int number, char replacement);

        bool HasWon(char symbol);

        int GetNumbersLeft();
    }
}
