namespace Labyrinth.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Labyrinth.Commons;
    using Renderer.Contracts;

    /// <summary>
    /// Class for holding and handling console game.
    /// </summary>
    public class GameConsole : Entity, IGameConsole
    {
        /// <summary>
        /// Default game line length.
        /// </summary>
        private const int DefaultLineLength = 60;

        /// <summary>
        /// Default game lines count.
        /// </summary>
        private const int DefaultLinesMaxCount = 100;

        /// <summary>
        /// Game dialog list.
        /// </summary>
        private ILanguageStrings dialogList;

        /// <summary>
        /// Game line length.
        /// </summary>
        private int lineLength;

        /// <summary>
        /// Game lines max count.
        /// </summary>
        private int linesMaxCount;

        /// <summary>
        /// List of lines in the game.
        /// </summary>
        private LinkedList<string> lines;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameConsole"/> class.
        /// </summary>
        /// <param name="dialogList">Dialog list for the game.</param>
        /// <param name="linesCount">Lines count for the game.</param>
        /// <param name="lineLength">Line length for the game.</param>
        public GameConsole(ILanguageStrings dialogList, int linesCount, int lineLength)
        {
            this.dialogList = dialogList;
            this.linesMaxCount = linesCount;
            this.lineLength = lineLength;
            this.lines = new LinkedList<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameConsole"/> class.
        /// </summary>
        /// <param name="dialogList">Dialog list for the game.</param>
        public GameConsole(ILanguageStrings dialogList)
            : this(dialogList, DefaultLinesMaxCount, DefaultLineLength)
        {
        }

        /// <summary>
        /// Gets the lines for the dialog.
        /// </summary>
        /// <param name="numberOfLines">Number of lines.</param>
        /// <returns>String array of the lines.</returns>
        public string[] GetLastLines(int numberOfLines)
        {
            int outputLinesCount = Math.Min(numberOfLines, this.lines.Count);
            string[] output = new string[outputLinesCount];

            string[] linesCopy = new string[this.lines.Count];

            this.lines.CopyTo(linesCopy, 0);
            int numberOfLinesToSkip = this.lines.Count - outputLinesCount;
            for (int i = 0; i < outputLinesCount; i++)
            {
                if (i < 4)
                {
                    output[i] = linesCopy[i];
                }
                else
                {
                    output[i] = linesCopy[i + numberOfLinesToSkip];
                }
            }

            // Fix for bug 1337
            if (this.lines.Last.Value.Trim() == this.dialogList.GetDialog(Dialog.EnterName).Trim())
            {
                this.lines.RemoveLast();

                this.lines.AddLast(this.dialogList.GetDialog(Dialog.NameAdded));
            }

            return output;
        }

        /// <summary>
        /// Adds a string to the input with arguments.
        /// </summary>
        /// <param name="key">Dialog key for the current input.</param>
        /// <param name="args">String array of formatting arguments.</param>
        public void AddInput(Dialog key, string[] args)
        {
            string input = this.GetInput(key);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(input, args);
            input = sb.ToString();
            this.EnqueueInput(input);
        }

        /// <summary>
        /// Adds a string to the input without arguments.
        /// </summary>
        /// <param name="key">Dialog key for the current input.</param>
        public void AddInput(Dialog key)
        {
            string input = this.GetInput(key);
            this.EnqueueInput(input);
        }

        /// <summary>
        /// Gets the string representing the supplied dialog key.
        /// </summary>
        /// <param name="key">Dialog key</param>
        /// <returns>String representing the supplied dialog key.</returns>
        private string GetInput(Dialog key)
        {
            string input = this.dialogList.GetDialog(key);
            return input;
        }

        /// <summary>
        /// Splits a string into words.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>String array containing the words.</returns>
        private string[] GetWords(string input)
        {
            char[] whiteSpace = { ' ' };
            string[] words = input.Split(whiteSpace);
            return words;
        }

        /// <summary>
        /// Gets the lines of the input.
        /// </summary>
        /// <param name="input">String input.</param>
        /// <returns>List of the lines of the input.</returns>
        private List<string> GetLines(string input)
        {
            Queue<string> words = new Queue<string>(this.GetWords(input));

            List<string> lines = new List<string>();

            StringBuilder currentLine = new StringBuilder();
            while (words.Count > 0)
            {
                string word = (string)words.Dequeue();
                if (currentLine.Length + word.Length < this.lineLength)
                {
                    currentLine.Append(word);
                    currentLine.Append(" ");
                }
                else
                {
                    lines.Add(currentLine.ToString());
                    currentLine.Clear();
                    currentLine.Append(word);
                    currentLine.Append(" ");
                }
            }

            if (currentLine.Length > 0)
            {
                lines.Add(currentLine.ToString());
            }

            return lines;
        }

        /// <summary>
        /// Enqueues a string to the input.
        /// </summary>
        /// <param name="input">String for enqueue.</param>
        private void EnqueueInput(string input)
        {
            List<string> linesList = this.GetLines(input);

            foreach (string line in linesList)
            {
                this.lines.AddLast(line);
            }
        }
    }
}