// ********************************
// <copyright file="ILogger.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Loggers.Contracts
{
    /// <summary>
    /// Implement this interface to cerate a new type of logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">String value that gets logged.</param>
        void Log(string message);
    }
}