namespace Labyrinth
{
    using System;
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
            var inputLine = Console.ReadKey();
            //inputLine = inputLine.Trim().ToLower();
            switch (inputLine.KeyChar)
            {
                case 'w': return Command.Up;
                case 's': return Command.Down;
                case 'd': return Command.Right;
                case 'a': return Command.Left;
                case 'r': return Command.Restart;
                case 'e': return Command.Exit;
                case 't': return Command.Top;
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
