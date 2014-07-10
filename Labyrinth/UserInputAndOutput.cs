using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class UserInputAndOutput : IUserInput
    {
        //public static string GetInput()
        //{
        //    string inputLine = Console.ReadLine();
        //    return inputLine;
        //}
        //TODO: Refactor strings
        public Command GetInput()
        {
            string inputLine = Console.ReadLine();
            inputLine = inputLine.Trim().ToLower();
            switch (inputLine)
            {
                case "w": return Command.Up;
                case "s": return Command.Down;
                case "d": return Command.Right;
                case "a": return Command.Left;
                case "restart": return Command.Restart;
                case "exit": return Command.Exit;
                case "top": return Command.Top;
                default:
                    return Command.InvalidInput;
            }
        }

        public string GetPlayerName()
        {
            string inputLine = Console.ReadLine();
            return inputLine.Trim();
        }
    }
}
