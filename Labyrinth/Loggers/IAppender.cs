namespace Labyrinth.Loggers
{
    using System;
    using System.Collections;

    public interface IAppender
    {
        ulong MessageCount { get; }

        void AddMessage(string message);
    }
}