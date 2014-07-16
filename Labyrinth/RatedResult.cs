namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class RatedResult : Result, IResult
    {
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

        public RatedResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Rating = (PlayerRating)info.GetValue("rating", typeof(PlayerRating));
        }

        public PlayerRating Rating { get; private set; }

        public override string ToString()
        {
            return base.Formatter.Format(
                string.Format("{0} ({1})\t", this.PlayerName, this.Rating),
                this.MovesCount.ToString());
        }

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("rating", this.Rating);
        }
    }
}
