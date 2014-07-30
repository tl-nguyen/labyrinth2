// ********************************
// <copyright file="IAppender.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Loggers.Contracts
{
    /// <summary>
    /// Implement this interface to cerate a new type of <see cref="IAppender"/>
    /// </summary>
    public interface IAppender
    {
        /// <summary>
        /// Gets the message count in the <see cref="IAppender"/>.
        /// </summary>
        ulong MessageCount { get; }

        /// <summary>
        /// Adds a message.
        /// </summary>
        /// <param name="message">Receives a string.</param>
        void AddMessage(string message);
    }
}