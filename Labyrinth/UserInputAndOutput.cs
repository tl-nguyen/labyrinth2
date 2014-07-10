namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
                case "u": return Command.Up;
                case "d": return Command.Down;
                case "r": return Command.Right;
                case "l": return Command.Left;
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
