// ********************************
// <copyright file="TopResults.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public delegate void ChangedTopResultsEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Represents a table with the top results
    /// </summary>
    public class TopResults
    {
        public event ChangedTopResultsEventHandler Changed;

        /// <summary>
        /// Maximum count of top results in the table.
        /// </summary>
        private const int MaxCount = 5;

        /// <summary>
        /// Holds the sorted list of top results.
        /// </summary>
        private List<Result> topResults;
       
        /// <summary>
        /// Initializes static members of the <see cref="TopResults"/> class.
        /// </summary>
        static TopResults()
        {
            List = new TopResults();
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="TopResults"/> class from being created.
        /// </summary>
        private TopResults()
        {
            this.topResults = new List<Result>();
            this.topResults.Capacity = TopResults.MaxCount;
        }

        /// <summary>
        /// Gets the list of top results.
        /// </summary>
        public static TopResults List { get; private set; }

        /// <summary>
        /// Converts the result table into string.
        /// </summary>
        /// <returns>String representing the converted results table.</returns>
        public override string ToString()
        {
            var output = new List<string>();
            if (this.topResults.Count == 0)
            {
                output.Add(UserInputAndOutput.SCOREBOARD_EMPTY_MSG);
            }
            else
            {
                for (int i = 0; i < this.topResults.Count; i++)
                {
                    output.Add(string.Format("{0}. {1} --> {2} moves", i + 1, this.topResults[i].PlayerName, this.topResults[i].MovesCount));
                }
            }

            return string.Join(Environment.NewLine, output);
        }

        /// <summary>
        /// Checks if a given amount of moves is good enough to enter the results table.
        /// </summary>
        /// <param name="currentMoves">Integer value representing the amount of moves.</param>
        /// <returns>True if a result is good enough and false if the result is not good enough to enter the results table.</returns>
        internal bool IsTopResult(int currentMoves)
        {
            if (this.topResults.Count < TopResults.MaxCount)
            {
                return true;
            }

            if (currentMoves < this.topResults.Max().MovesCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a new result formed form specified moves and player name in the results table.
        /// </summary>
        /// <param name="result">Player result to be added.</param>
        internal void Add(Result result)
        {
            if (this.topResults.Count == this.topResults.Capacity)
            {
                this.topResults[this.topResults.Count - 1] = result;
            }
            else
            {
                this.topResults.Add(result);
            }

            this.topResults.Sort();
            OnChanged(EventArgs.Empty);
            
        }

        private void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public void Parse(string list)
        {
            this.topResults = new List<Result>();
            this.topResults.Capacity = TopResults.MaxCount;
            var lines = list.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                var start = lines[i].IndexOf(". ");
                var middle = lines[i].IndexOf(" --> ");
                var end = lines[i].IndexOf(" moves");
                var result = new Result(
                    int.Parse(lines[i].Substring(middle + 5, end - middle - 5)),
                    lines[i].Substring(start + 2, middle - start - 2));
                this.topResults.Add(result);
            }
        }
    }
}
