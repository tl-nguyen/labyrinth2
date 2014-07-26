namespace Labyrinth.Entities.Contracts
{
    using Labyrinth.Commons;

    public interface IGameConsole : IEntity
    {
        void AddInput(Dialog key, string[] args);

        void AddInput(Dialog key);

        string[] GetLastLines(int numberOfLines);
    }
}