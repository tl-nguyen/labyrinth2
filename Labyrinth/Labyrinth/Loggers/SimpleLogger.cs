// ********************************
// <copyright file="SimpleLogger.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Loggers
{
    using System;
    using Contracts;

    /// <summary>
    /// This class is a simple logger. It format messages by adding a current date time to them
    /// </summary>
    public class SimpleLogger : ILogger
    {
        private IAppender appender;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLogger" /> class
        /// </summary>
        /// <param name="appender">Simple logger needs an <see cref="IAppender"/> to store the formatted messages</param>
        public SimpleLogger(IAppender appender)
        {
            if (appender == null)
            {
                throw new ArgumentException("The Appender must be instanciated before the logger!");
            }

            this.appender = appender;
        }

        /// <summary>
        /// This method store a message into a storage
        /// </summary>
        /// <param name="message">A message to be stored</param>
        public void Log(string message)
        {
            this.appender.AddMessage(DateTime.Now + " : " + message);
        }
    }
}