using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameBoard
    {
        String[] boardLines;
        int boardSize;

        public GameBoard() : this(3)
        {

        } 

        public GameBoard(int boardSize)
        {
            this.boardSize = boardSize > 0 ? boardSize : 3;
            Reset();
        }

        internal void Reset()
        {
            List<String> lines = new List<string>();

            StringBuilder lineBuilder = new StringBuilder();
            for (int i = 0; i < boardSize * 5; i++)
            {
                lineBuilder.Append("-");
            }
            lines.Add(lineBuilder.ToString());

            int counter = -1;

            StringBuilder rowBuilder;
            for (int y = 0; y < boardSize; y++)
            {
                rowBuilder = new StringBuilder("|");
                for (int x = 0; x < boardSize; x++)
                {
                    counter += 1;
                    rowBuilder.Append(" " + counter + " |");
                }
                lines.Add(rowBuilder.ToString());
                lines.Add(lineBuilder.ToString());
            }

            boardLines = lines.ToArray();
            Console.WriteLine(boardLines.Count());
        }

        public String toString()
        {
            StringBuilder resultBuilder = new StringBuilder();
            for (int i = 0; i < boardLines.Count(); i++)
            {
                resultBuilder.Append(boardLines[i] + "\n");
            }
            return resultBuilder.ToString();
        }

    }
}
