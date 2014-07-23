namespace Labyrinth.Renderer
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class LanguageStrings : ILanguageStrings
    {
        private readonly Dictionary<string, string> dialogList;

        public LanguageStrings()
        {
            this.dialogList = new Dictionary<string, string>();

            this.dialogList.Add("InvalidMove", "Invalid move!");
            this.dialogList.Add("InvalidCommand", "Invalid command!");
            this.dialogList.Add("EnterName", "Please enter your name for the top scoreboard:");
            this.dialogList.Add("GoodBye", "Good Bye" + "\n" + "Press any key to exit..." + "\n");
            this.dialogList.Add("Input", "Enter your move (A-left, D-right, W-up, S-down)");
            this.dialogList.Add("Welcome",
                                    "Welcome to “Labirinth” game." + "\n" +
                                    " Please try to escape." +
                                    " Use 't' to view the top scoreboard," + "\n" +
                                    " 'r' to start a new game and 'e' to quit the game.");
            this.dialogList.Add("WinMessage", "Congratulations! You escaped in {0} moves.");
            this.dialogList.Add("AllWrong", "If this happens something is very wrong with the logic of PrintLabyrinth method");

            this.dialogList.Add("WelcomeV2", "Welcome to “Labyrinth” game. Please try to escape. Use 't' to view the top scoreboard, 'r' to start a new game and 'e' to quit the game.");
        }

        /// <summary>
        /// Get a diaglog from the dialogList
        /// </summary>
        /// <param name="key">The dialog key that you want to get</param>
        /// <returns>The wanted dialog</returns>
        public string GetDialog(string key)
        {
            if (this.dialogList.ContainsKey(key))
            {
                return this.dialogList[key];
            }
            else
            {
                throw new ArgumentOutOfRangeException("there's no such key in dialogList");
            }
        }
    }
}