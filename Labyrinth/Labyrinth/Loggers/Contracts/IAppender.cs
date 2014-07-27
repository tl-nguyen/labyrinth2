// ********************************
// <copyright file="IAppender.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Loggers.Contracts
{
    public interface IAppender
    {
        ulong MessageCount { get; }

        void AddMessage(string message);
    }
}