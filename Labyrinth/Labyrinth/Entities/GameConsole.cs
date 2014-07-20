namespace Labyrinth.Entities
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Renderer.Contracts;
    using Contracts;

    public class GameConsole : Entity, IGameConsole
    {
        private const int DEFAULT_LINE_LENGTH = 60;
        private const int DEFAULT_LINES_MAX_COUNT = 100;

        private ILanguageStrings dialogList;
        private int lineLength;
        private int linesMaxCount;
        private Queue<string> lines;

        public GameConsole(ILanguageStrings dialogList, int linesCount, int lineLength)
        {
            this.dialogList = dialogList;
            this.linesMaxCount = linesCount;
            this.lineLength = lineLength;
            this.lines = new Queue<string>();
        }
        public GameConsole(ILanguageStrings dialogList)
            : this(dialogList, DEFAULT_LINES_MAX_COUNT, DEFAULT_LINE_LENGTH)
        {
        }

        public string[] GetLastLines(int numberOfLines)
        {
            int outputLinesCount = Math.Min(numberOfLines, this.lines.Count);
            string[] output = new string[outputLinesCount];

            string[] linesCopy = new string[this.lines.Count];
            this.lines.CopyTo(linesCopy, 0);
            int numberOfLinesToSkip = this.lines.Count - outputLinesCount;
            for (int i = 0; i < outputLinesCount; i++)
            {
                output[i] = linesCopy[i + numberOfLinesToSkip];
            }
            return output;
        }
        public void AddInput(string key, string[] args)
        {
            string input = this.GetInput(key);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(input, args);
            input = sb.ToString();
            this.EnqueueInput(input);
        }
        public void AddInput(string key)
        {
            string input = this.GetInput(key);
            this.EnqueueInput(input);
        }

        private string GetInput(string key)
        {
            string input = this.dialogList.GetDialog(key);
            return input;
        }
        private string[] GetWords(string input)
        {
            char[] whiteSpace = { ' ' };
            string[] words = input.Split(whiteSpace);
            return words;
        }
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
        private void EnqueueInput(string input)
        {
            List<string> linesList = GetLines(input);

            foreach (string line in linesList)
            {
                this.lines.Enqueue(line);
            }

            if (this.lines.Count > this.linesMaxCount)
            {
                while (this.lines.Count > this.linesMaxCount)
                {
                    this.lines.Dequeue();
                }
            }
        }
    }
}
