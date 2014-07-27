// ********************************
// <copyright file="IResultsTable.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Entities.Contracts
{
    using Results.Contracts;

    public interface IResultsTable : IEntity
    {
        ITable Table { get; }
    }
}