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

        public bool TryMove(Command direction, ILabyrinth labyrinth)
        {
            bool moveDone = false;
            switch (direction)
            {
                case Command.Up:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Up);
                    break;
                case Command.Down:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Down);
                    break;
                case Command.Left:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Left);
                    break;
                case Command.Right:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Right);
                    break;
                default:
                    //renderer.RenderInvalidMove();
                    break;
            }

            //if (moveDone == false)
            //{
            //    renderer.RenderInvalidMove();
            //}

            return moveDone;
        }
    }
}
