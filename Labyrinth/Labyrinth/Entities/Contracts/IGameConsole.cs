namespace Labyrinth.Entities.Contracts
{
    public interface IGameConsole : IEntity
    {
        void AddInput(string key, string[] args);

        void AddInput(string key);

        string[] GetLastLines(int numberOfLines);
    }
}