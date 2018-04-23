using System;
using TicTacToeLibrary;
using System.Diagnostics;

namespace TicTacToeConsole
{
    class Program
    {

        private static readonly TicTacToeEngine engine = new TicTacToeEngine(4, new LoopList<Player> { new Player('X'), new Player('O'), new Player('#') });

        static void Main(string[] args)
        {
            StartConsoleApp();
        }

        private static void StartConsoleApp()
        {
            engine.Reset();

            while (!engine.GameFinished())
            {
                Console.WriteLine("Type a number from 1-9, new or quit");
                Console.WriteLine("Current Player: Player" + engine.GetCurrentPlayer().GetSymbol());
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
                    else if (lowerInput == "quit")
                    {
                        return;
                    }
                    Console.WriteLine("Your input was invalid.");            
                }
            }

            if (engine.Status.ToString().ToLower().Contains("won"))
            {
                Console.WriteLine("Player {0} won!", engine.GetCurrentPlayer().GetSymbol());
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
