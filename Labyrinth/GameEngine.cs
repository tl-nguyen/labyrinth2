namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for generating the main logic of the game 
    /// </summary>
    public class GameEngine    
    {
        private IRenderer renderer;
        private IUserInput input;
        private Player player;
        private TopResults table;
        /// <summary>
        /// Property used for ending the game loop in Run method
        /// </summary>
        private bool hasEndedGame { get; set; }

        public GameEngine(IRenderer renderer, IUserInput input)
        {
            this.input = input;
            this.renderer = renderer;
            this.player = LabyrinthFactory.GetPlayerInstance(LabyrinthFactory.GetLabyrinthInstance());
            this.table = LabyrinthFactory.GetTopResultsInstance();
            this.table.Changed += (sender, e) =>
            {
                LabyrinthFactory.GetSerializationManagerInstance().Serialize(sender);
            };
            renderer.RenderWelcomeMessage();
        }
        /// <summary>
        /// Public method used to run the game 
        /// </summary>
        public void Run()
        {
            while (!this.hasEndedGame)
            {
                this.UpdateUserInput();
            }
        }
        /// <summary>
        /// Updates the state of user's input and renders the game according to it
        /// </summary>
        private void UpdateUserInput()
        {
            Command input = Command.InvalidInput;
            int movesCount = 0;

            while (!this.IsGameOver(this.player) && input != Command.Restart)
            {
                renderer.RenderLabyrinth(this.player.Labyrinth);
                renderer.RenderPromptInput();
                input = this.input.GetInput();
                renderer.Clear();
                this.ProccessInput(input, ref movesCount);
            }

            if (input != Command.Restart)
            {
                renderer.RenderWinMessage(movesCount);
                if (this.table.IsTopResult(movesCount))
                {
                    renderer.RenderEnterNameForScoreboard();
                    string name = this.input.GetPlayerName(); 
                    this.table.Add(new Result(movesCount, name));
                    
                }
                this.hasEndedGame = true;
            }
            
        }
        /// <summary>
        /// Checks if the user has made his way out of the labyrinth
        /// </summary>
        /// <param name="player">The object which current position is checked</param>
        /// <returns>True if the player has got out of the labyrinth, false if not</returns>
        private bool IsGameOver(Player player)
        {
            bool isGameOver = false;
            int currentRow = player.CurrentCell.Row;
            int currentCol = player.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Labyrinth.LABYRINTH_SIZE - 1 ||
                currentCol == Labyrinth.LABYRINTH_SIZE - 1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }
        /// <summary>
        /// Handles the user's input
        /// </summary>
        /// <param name="input">The current input command of the user</param>
        /// <param name="movesCount">The count of player's move done already</param>
        private void ProccessInput(Command input, ref int movesCount)
        {
            switch (input)
            {
                case Command.Up:
                case Command.Down:
                case Command.Left:
                case Command.Right:
                    bool moveDone =
                        this.player.MoveAction(input);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }
                    else
                    {
                        renderer.RenderInvalidMove();
                    }
                    break;
                case Command.Top:
                    renderer.RenderTopResults(this.table.ToString());
                    break;
                case Command.Exit:
                    renderer.RenderExitMessage();
                    Environment.Exit(0);
                    break;
                case Command.Restart:
                    break;
                default:
                    renderer.RenderInvalidCommand();
                    break;
            }
        }
    }
}
