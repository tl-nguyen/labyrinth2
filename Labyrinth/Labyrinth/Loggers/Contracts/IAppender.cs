namespace Labyrinth.Loggers.Contracts
{
    using System;
    using System.Collections;

    public interface IAppender
    {
        ulong MessageCount { get; }

        void AddMessage(string message);
    }
}