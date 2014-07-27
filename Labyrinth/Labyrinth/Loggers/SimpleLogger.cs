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

    public class SimpleLogger : ILogger
    {
        private IAppender appender;

        public SimpleLogger(IAppender appender)
        {
            if (appender == null)
            {
                throw new ArgumentException("The Appender must be instanciated before the logger!");
            }

            this.appender = appender;
        }

        public void Log(string message)
        {
            appender.AddMessage(DateTime.Now + " : " + message);
        }
    }
}