// ********************************
// <copyright file="ResultsTable.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Entities
{
    using Contracts;
    using Results.Contracts;

    public class ResultsTable : Entity, IResultsTable
    {
        public ITable Table { get; private set; }

        public ResultsTable(ITable table)
        {
            this.Table = table;
        }
    }
}