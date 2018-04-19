using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    class MatrixGameBoard : IGameBoard
    {
        private int boardSize;
        private string[,] matrix;

        public MatrixGameBoard() : this(3) { }

        public MatrixGameBoard(int size) {
            this.boardSize = boardSize > 0 ? boardSize : 3;
            Reset();
        }

        public int GetNumbersLeft()
        {
            int total = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (int.TryParse(matrix[i, y], out int parseRes))
                    {
                        total += 1;
                    }
                }
            }
            return total;
        }

        public bool HasWon(char symbol)
        {
            Console.WriteLine("Symbol: "  + symbol);
            // Checking rows horizontally
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                int horCounter = 0;
                int verCounter = 0;
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    horCounter = symbol.ToString().Equals(matrix[x, y]) ? horCounter + 1 : 0;
                    verCounter = symbol.ToString().Equals(matrix[y, x]) ? verCounter + 1 : 0;

                    if (horCounter >= 3 || verCounter >= 3)
                        return true;
                }
            }


            // Checking diag
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1) - (boardSize - 1); y++)
                {
                    
                    if (symbol.ToString().Equals(matrix[i, y]))
                    {
                        // Check left and right
                        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                        {
                            if (CheckDiag(dir, i, y, symbol))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool CheckDiag(Direction dir, int i, int y, char symbol)
        {
            int counter = 1;
            for (int l = y + 1; l < matrix.GetLength(1); l++)
            {
                i = dir == Direction.Left ? i - 1 : i + 1;
                if (i < 0 || i >= matrix.GetLength(0) || !symbol.ToString().Equals(matrix[i, l]))
                    break;

                counter += 1;
                if (counter >= 3)
                    return true;
            }
            return counter >= 3;
        }

        public override String ToString()
        {
            StringBuilder resultBuilder = new StringBuilder();

            StringBuilder lineBuilder = new StringBuilder();
            for (int i = 0; i < boardSize * 5; i++)
            {
                lineBuilder.Append("-");
            }
            string line = lineBuilder.ToString();
            resultBuilder.Append(line +"\n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                StringBuilder rowBuilder = new StringBuilder("|");
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    rowBuilder.Append(" " + (matrix[i, y]) + " |");
                }
                resultBuilder.Append(rowBuilder.ToString() + "\n");
                resultBuilder.Append(lineBuilder.ToString() + "\n");
            }
            return resultBuilder.ToString();
        }

        public bool ReplaceNumber(int number, char replacement)
        {
            // Out of range
            if (number < 1 || number > (matrix.GetLength(0) * matrix.GetLength(1)))
                return false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (int.TryParse(matrix[i, y], out int parseRes))
                    {
                        if (parseRes.Equals(number))
                        {
                            matrix[i, y] = replacement.ToString();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Reset()
        {
            matrix = new string[boardSize, boardSize];
            int counter = 1;
            for (int i = 0; i < boardSize; i++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    matrix[i, y] = counter.ToString();
                    counter += 1;
                }
            }
        }

        private enum Direction { Left, Right }

    }
}
