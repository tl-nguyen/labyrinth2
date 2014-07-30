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

    /// <summary>
    /// This is a class to be used for temporary storage of information in memory
    /// </summary>
    public class MemoryAppender : IAppender
    {
        private static IAppender instance;
        private ulong messageCount;
        private List<string> storage;

        /// <summary>
        /// Prevents a default instance of the <see cref="MemoryAppender"/> class from being created.
        /// </summary>
        private MemoryAppender()
        {
            this.messageCount = 0;
            this.storage = new List<string>();
        }

        /// <summary>
        /// Gets a number of currently logged messages
        /// </summary>
        public ulong MessageCount
        {
            get { return this.messageCount; }
        }

        /// <summary>
        /// This method is used to return the memory logger instance
        /// </summary>
        /// <returns>A MemoryLogger</returns>
        public static IAppender GetInstance()
        {
            if (instance == null)
            {
                instance = new MemoryAppender();
            }

            return instance;
        }

        /// <summary>
        /// This method is used to get all messages stored in the memory storage
        /// </summary>
        /// <param name="appender">Instance of the current memory <see cref="IAppender"/></param>
        /// <param name="match">Predicate to be used as constraint to get some messages from a memory storage</param>
        /// <returns>List of strings that match the predicate</returns>
        public static List<string> GetMessages(IAppender appender, Predicate<string> match)
        {
            MemoryAppender memoryAppender = appender as MemoryAppender;
            if (memoryAppender == null)
            {
                throw new ArgumentException("The appender must be of type MemoryAppender!");
            }

            return memoryAppender.storage.FindAll(match);
        }

        /// <summary>
        /// Add a passed message to the memory storage
        /// </summary>
        /// <param name="message">Message to be store in a memory storage</param>
        public void AddMessage(string message)
        {
            this.messageCount++;
            this.storage.Add(message);
        }
    }
}