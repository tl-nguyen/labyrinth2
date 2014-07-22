namespace Labyrinth.Loggers.Contracts
{
    public interface IAppender
    {
        ulong MessageCount { get; }

        void AddMessage(string message);
    }
}