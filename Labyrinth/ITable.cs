namespace Labyrinth
{
    using System.Runtime.Serialization;

    public interface ITable : ISerializable
    {
        event ChangedTableEventHandler Changed;

        bool IsTopResult(int currentMoves);

        void Add(IResult result);
    }
}
