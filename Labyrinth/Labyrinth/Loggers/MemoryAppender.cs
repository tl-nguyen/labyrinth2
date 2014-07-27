// ********************************
// <copyright file="MemoryAppender.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Loggers
{
    using System;
    using System.Collections.Generic;
    using Contracts;

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

        public static List<string> GetMessages(IAppender appender, Predicate<string> match)
        {
            MemoryAppender memoryAppender = appender as MemoryAppender;
            if (memoryAppender == null)
            {
                throw new ArgumentException("The appender must be of type MemoryAppender!");
            }

            return memoryAppender.storage.FindAll(match);
        }
    }
}