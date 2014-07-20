namespace Labyrinth.Entities.Contracts
{
    using System.Collections.Generic;
    public interface IGameConsole : IEntity
    {
        void AddInput(string key, string[] args);
        void AddInput(string key);
        string[] GetLastLines(int numberOfLines);
    }
}
