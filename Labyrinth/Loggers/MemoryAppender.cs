namespace Labyrinth.Loggers
{
    using System;
    using System.Collections.Generic;

    public class MemoryAppender : IAppender
    {
        private static IAppender instance;
        private ulong messageCount;
        private List<string> storage;

        private MemoryAppender()
        {
            this.messageCount = 0;
            this.storage = new List<string>();
        }

        public static IAppender GetInstance()
        {
            if (instance == null)
            {
                instance = new MemoryAppender();
            }

            return instance;
        }

        public ulong MessageCount
        {
            get { return this.messageCount; }
        }

        public void AddMessage(string message)
        {
            this.messageCount++;
            this.storage.Add(message);
        }

        public List<string> GetMessages(Predicate<string> match)
        {
            return this.storage.FindAll(match);
        }
    }
}