namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class Result : IComparable, IResult
    {
        private int movesCount; 
        private string playerName;
        private IResultFormatter formatter;

        protected Result(int movesCount, string playerName, IResultFormatter formatter)
        {
            this.movesCount = movesCount;
            this.playerName = playerName;
            this.formatter = formatter;
        }

        protected Result(SerializationInfo info, StreamingContext context)
        {
            this.playerName = (string)info.GetValue("playerName", typeof(string));
            this.movesCount = (int)info.GetValue("movesCount", typeof(int));
            this.formatter = (IResultFormatter)info.GetValue("formatter", typeof(IResultFormatter));
        }

        public int MovesCount
        {
            get
            {
                return this.movesCount;
            }
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
        }

        public IResultFormatter Formatter
        {
            get
            {
                return this.formatter;
            }
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("playerName", this.PlayerName, typeof(string));
            info.AddValue("movesCount", this.MovesCount, typeof(int));
            info.AddValue("formatter", this.formatter, typeof(IResultFormatter));
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Could not compare to null!");
            }
            var other = obj as Result;
            if(other == null)
            {
                throw new ArgumentException("Only other Result can be compared to this Result!");
            }
            int compareResult = this.MovesCount.CompareTo(other.MovesCount);
            return compareResult;
        }
    }
}
