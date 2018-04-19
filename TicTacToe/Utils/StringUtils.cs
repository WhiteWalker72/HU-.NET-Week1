using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Utils
{
    class StringUtils
    {
        public static int GetStringInteger(string input)
        {
            StringBuilder resultBuilder = new StringBuilder();
            foreach (char ch in input)
            {
                if (char.IsDigit(ch))
                {
                    resultBuilder.Append(ch);
                }
            }
            return resultBuilder.Length > 0 ? int.Parse(resultBuilder.ToString()) : -1;
        }
    }
}
