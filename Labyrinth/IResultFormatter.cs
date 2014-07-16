namespace Labyrinth
{
    using System.Runtime.Serialization;

    public interface IResultFormatter : ISerializable
    {
        string Format(string name, string moves);
    }
}
