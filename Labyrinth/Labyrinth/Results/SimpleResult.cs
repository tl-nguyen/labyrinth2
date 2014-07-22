// ********************************
// <copyright file="SimpleResult.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Results
{
    using Contracts;
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for simple game results.
    /// </summary>
    [Serializable]
    public class SimpleResult : Result, IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleResult"/> class.
        /// </summary>
        /// <param name="movesCount">Count of moves</param>
        /// <param name="playerName">Name of the player</param>
        /// <param name="formatter">ToString() result formatter</param>
        public SimpleResult(int movesCount, string playerName, IResultFormatter formatter)
            : base(movesCount, playerName, formatter)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleResult"/> class used in deserialization process.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Serialization streaming context</param>
        public SimpleResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Converts the result to string.
        /// </summary>
        /// <returns>String representing the result</returns>
        public override string ToString()
        {
            return this.Formatter.Format(this.PlayerName, this.MovesCount.ToString());
        }
    }
}