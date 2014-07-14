using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class LanguageStrings : ILanguageStrings
    {
        public Dictionary<string, string> DialogList { get; private set; }
 
        public LanguageStrings()
        {
            this.DialogList = new Dictionary<string, string>();

            this.DialogList.Add("InvalidMove", "Invalid move!");
            this.DialogList.Add("InvalidCommand", "Invalid command!");
            this.DialogList.Add("EnterName", "Please enter your name for the top scoreboard:");
            this.DialogList.Add("GoodBye", "Good Bye");
            this.DialogList.Add("Input", "Enter your move (A-left, D-right, W-up, S-down)");
            this.DialogList.Add("Welcome",
                                    "Welcome to “Labirinth” game." + "\n" +
                                    " Please try to escape." +
                                    " Use 't' to view the top scoreboard," + "\n" +
                                    " 'r' to start a new game and 'e' to quit the game.");
            this.DialogList.Add("WinMessage", "Congratulations! You escaped in {0} moves.");
            this.DialogList.Add("AllWrong", "If this happens something is very wrong with the logic of PrintLabyrinth method");
        }

        public string GetDialog(string key)
        {
            if (this.DialogList.ContainsKey(key))
            {
                return this.DialogList[key];
            }
            else
            {
                throw new ArgumentOutOfRangeException("there's no such key in dialogList");
            }
        }
    }
}
