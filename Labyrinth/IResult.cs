namespace Labyrinth
{
    public interface IResult
    {
        int MovesCount { get; }

        string PlayerName { get; }

        int CompareTo(IResult other);
    }
}