// ********************************
// <copyright file="RatedResult.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Results
{
    using System;
    using System.Runtime.Serialization;
    using Contracts;

    /// <summary>
    /// Class for game results with rating.
    /// </summary>
    [Serializable]
    public class RatedResult : Result, IResult
    {
        /// <summary>
        /// Constant for maximum length of the player name.
        /// </summary>
        private const int MaxPlayerNameLength = 6;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatedResult"/> class.
        /// </summary>
        /// <param name="movesCount">Count of moves</param>
        /// <param name="playerName">Name of the player</param>
        /// <param name="formatter">ToString() result formatter</param>
        public RatedResult(int movesCount, string playerName, IResultFormatter formatter)
            : base(movesCount, playerName, formatter)
        {
            if (movesCount <= (int)PlayerRating.Master)
            {
                this.Rating = PlayerRating.Master;
            }
            else if (movesCount <= (int)PlayerRating.Player)
            {
                this.Rating = PlayerRating.Player;
            }
            else
            {
                this.Rating = PlayerRating.Beginner;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RatedResult"/> class used in deserialization process.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Serialization streaming context</param>
        public RatedResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Rating = (PlayerRating)info.GetValue("rating", typeof(PlayerRating));
        }

        /// <summary>
        /// Gets the player result rating.
        /// </summary>
        public PlayerRating Rating { get; private set; }

        /// <summary>
        /// Converts the result to string.
        /// </summary>
        /// <returns>String representing the result</returns>
        public override string ToString()
        {
            string shortenedName = this.PlayerName;
            if(this.PlayerName.Length >= RatedResult.MaxPlayerNameLength)
            {
                shortenedName = this.PlayerName.Substring(0, RatedResult.MaxPlayerNameLength);
            }
            
            return this.Formatter.Format(
                string.Format("{0} ({1})\t", shortenedName, this.Rating),
                this.MovesCount.ToString());
        }

        /// <summary>
        /// Collects data from this instance for serialization.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Serialization streaming context</param>
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("rating", this.Rating);
        }
    }
}
