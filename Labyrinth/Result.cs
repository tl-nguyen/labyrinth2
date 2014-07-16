namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class Result : IComparable, IResult
    {
        private int movesCount; 
        private string playerName;

        public Result(int movesCount, string playerName)
        {
            this.movesCount = movesCount;
            this.playerName = playerName;
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("playerName", this.PlayerName, typeof(string));
            info.AddValue("movesCount", this.MovesCount, typeof(int));
        }

        public Result(SerializationInfo info, StreamingContext context)
        {
            this.playerName = (string)info.GetValue("playerName", typeof(string));
            this.movesCount = (int)info.GetValue("movesCount", typeof(int));
        }

        public override string ToString()
        {
            return string.Format("{0} --> {1} moves", this.PlayerName, this.MovesCount);
        }
    }
}
