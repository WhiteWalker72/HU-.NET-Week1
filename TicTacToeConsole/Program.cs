using System;
using TicTacToeLibrary;
using System.Diagnostics;

namespace TicTacToeConsole
{
    class Program
    {

        private static readonly TicTacToeEngine engine = new TicTacToeEngine();

        static void Main(string[] args)
        {
            StartConsoleApp();
        }

        private static void StartConsoleApp()
        {
            engine.Reset();

            while (!engine.GameFinished())
            {
                Console.WriteLine("Type a number from 1-9, new, gui or quit");
                Console.WriteLine("Status: " + engine.Status);
                Console.WriteLine(engine.Board());
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    if (engine.ChooseCell(number))
                        continue;
                    else
                    {
                        Console.WriteLine("Error: Input out of range or this cell is already taken.");
                        continue;
                    }
                }
                else
                {
                    string lowerInput = input.ToLower();
                    if (lowerInput == "new")
                    {
                        engine.Reset();
                        continue;
                    }
                    else if (lowerInput == "gui")
                    {
                        var proc = new Process();
                        proc.StartInfo.FileName = "C:\\Users\\sivar\\Documents\\Visual Studio 2017\\Projects\\HU-.NET-Week1\\" +
                            "TicTacToe\\bin\\Release\\TicTacToe.exe";
                        proc.StartInfo.Arguments = "-v -s -a";
                        proc.Start();
                        return;
                    } else if (lowerInput == "quit")
                    {
                        return;
                    }
                    Console.WriteLine("Your input was invalid.");
                    continue;
                }
            }
            if (engine.Status.ToString().ToLower().Contains("wins"))
            {
                char playerWon = engine.Status.Equals(GameStatus.PlayerOWins) ? 'O' : 'X';
                Console.WriteLine("Player {0} won!", playerWon);
            }
            else
            {
                Console.WriteLine("The game ended in a draw.");
            }

            Console.WriteLine("Restarting the game...");
            StartConsoleApp();
        }

    }
}
