namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SimpleResult : Result, IResult
    {
        public SimpleResult(int movesCount, string playerName, IResultFormatter formatter)
            : base(movesCount, playerName, formatter)
        {
        }

        public SimpleResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override string ToString()
        {
            return base.Formatter.Format(this.PlayerName, this.MovesCount.ToString());
        }
    }
}
