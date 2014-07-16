namespace Labyrinth
{
    using System.Runtime.Serialization;
    public interface IResult : ISerializable
    {
        int MovesCount { get; }

        string PlayerName { get; }

        int CompareTo(object other);
    }
}