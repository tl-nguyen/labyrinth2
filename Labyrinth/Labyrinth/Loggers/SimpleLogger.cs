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
    /// This class is a simple logger. It format messages by adding a current datetime to them
    /// </summary>
    public class SimpleLogger : ILogger
    {
        private IAppender appender;

        /// <summary>
        /// The method is used to return an instance of the simple logger
        /// </summary>
        /// <param name="appender">Simple logger need an appender to store the formated messages</param>
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
            appender.AddMessage(DateTime.Now + " : " + message);
        }
    }
}