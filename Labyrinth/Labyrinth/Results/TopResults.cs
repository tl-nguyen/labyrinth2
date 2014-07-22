// ********************************
// <copyright file="TopResults.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Results
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Delegate to changed event.
    /// </summary>
    /// <param name="sender">The object firing the event</param>
    /// <param name="e">Event arguments</param>
    public delegate void ChangedTableEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Represents a table with the top results
    /// </summary>
    [Serializable]
    public class TopResults : ITable
    {
        /// <summary>
        /// String representing an empty top results table.
        /// </summary>
        //private const string EmptyMessage = "|     The scoreboard is empty.     |";

        /// <summary>
        /// Maximum count of top results in the table.
        /// </summary>
        private const int MaxCount = 5;

        /// <summary>
        /// Holds the sorted list of top results.
        /// </summary>
        private List<IResult> topResults;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopResults"/> class.
        /// </summary>
        public TopResults()
        {
            this.topResults = new List<IResult>();
            this.topResults.Capacity = TopResults.MaxCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopResults"/> class.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Serialization streaming context</param>
        public TopResults(SerializationInfo info, StreamingContext context)
        {
            this.topResults = (List<IResult>)info.GetValue("topResults", typeof(List<IResult>));
        }

        /// <summary>
        /// Event for change in the top results list.
        /// </summary>
        public event ChangedTableEventHandler Changed;

        /// <summary>
        /// Returns a List of strings, containing the top results.
        /// If none are recorded, populates the list with only one string,
        /// "".
        /// </summary>
        /// <returns>Strings List representing the converted results table.</returns>
        public string[] GetTopResultsStrings()
        {
            int resultsListCount = this.topResults.Count;

            string[] output = new string[resultsListCount];
            for (int i = 0; i < resultsListCount; i++)
            {
                output[i] = this.topResults[i].ToString();
            }

            return output;
        }

        /// <summary>
        /// Checks if a given amount of moves is good enough to enter the results table.
        /// </summary>
        /// <param name="currentMoves">Integer value representing the amount of moves.</param>
        /// <returns>True if a result is good enough and false if the result is not good enough to enter the results table.</returns>
        public bool IsTopResult(int currentMoves)
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
        public void Add(IResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException("The result for adding could not be null!");
            }

            if (this.topResults.Count == this.topResults.Capacity)
            {
                this.topResults[this.topResults.Count - 1] = result;
            }
            else
            {
                this.topResults.Add(result);
            }

            this.topResults.Sort();
            this.OnChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Collects data from an object for serialization.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Serialization streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("topResults", this.topResults, typeof(List<IResult>));
        }

        /// <summary>
        /// This method fires the changed event for change in the top results.
        /// </summary>
        /// <param name="e">Event arguments</param>
        private void OnChanged(EventArgs e)
        {
            if (this.Changed != null)
            {
                this.Changed(this, e);
            }
        }
    }
}