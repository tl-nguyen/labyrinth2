namespace Labyrinth.Results
{
    using System;
    using System.Runtime.Serialization;
    using Contracts;

    /// <summary>
    /// Abstract class for game results.
    /// </summary>
    [Serializable]
    public abstract class Result : IComparable, IResult
    {
        /// <summary>
        /// Field for player moves count.
        /// </summary>
        private int movesCount;

        /// <summary>
        /// Field for player name.
        /// </summary>
        private string playerName;

        /// <summary>
        /// Field for result formatter.
        /// </summary>
        private IResultFormatter formatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="movesCount">Count of moves</param>
        /// <param name="playerName">Name of the player</param>
        /// <param name="formatter">ToString() result formatter</param>
        protected Result(int movesCount, string playerName, IResultFormatter formatter)
        {
            this.MovesCount = movesCount;
            this.PlayerName = playerName;
            this.Formatter = formatter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class used in deserialization process.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Serialization streaming context</param>
        protected Result(SerializationInfo info, StreamingContext context)
        {
            this.PlayerName = (string)info.GetValue("playerName", typeof(string));
            this.MovesCount = (int)info.GetValue("movesCount", typeof(int));
            this.Formatter = (IResultFormatter)info.GetValue("formatter", typeof(IResultFormatter));
        }

        /// <summary>
        /// Gets the count of player moves.
        /// </summary>
        public int MovesCount
        {
            get
            {
                return this.movesCount;
            }

            private set
            {
                if (value > 0)
                {
                    this.movesCount = value;
                }
                else
                {
                    throw new ArgumentException("The count of the moves have to pe positive number!");
                }
            }
        }

        /// <summary>
        /// Gets the player name.
        /// </summary>
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }

            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.playerName = value;
                }
                else
                {
                    throw new ArgumentException("The player name could not be null or empty!");
                }
            }
        }

        /// <summary>
        /// Gets the ToString() result formatter.
        /// </summary>
        public IResultFormatter Formatter
        {
            get
            {
                return this.formatter;
            }

            private set
            {
                if (value != null)
                {
                    this.formatter = value;
                }
                else
                {
                    throw new ArgumentNullException("The result formatter could not be null!");
                }
            }
        }

        /// <summary>
        /// Collects data from this instance for serialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Serialization streaming context.</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("playerName", this.PlayerName, typeof(string));
            info.AddValue("movesCount", this.MovesCount, typeof(int));
            info.AddValue("formatter", this.Formatter, typeof(IResultFormatter));
        }

        /// <summary>
        /// Compares two results.
        /// </summary>
        /// <param name="obj">Result for comparison.</param>
        /// <returns>Integer less than zero if this is less than other or zero if equal or greater than zero if this is greater than other.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Could not compare to null!");
            }

            var other = obj as Result;
            if (other == null)
            {
                throw new ArgumentException("Only other Result can be compared to this Result!");
            }

            int compareResult = this.MovesCount.CompareTo(other.MovesCount);
            return compareResult;
        }
    }
}