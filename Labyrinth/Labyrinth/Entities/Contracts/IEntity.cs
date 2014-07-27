// ********************************
// <copyright file="IEntity.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Entities.Contracts
{
    public interface IEntity
    {
        /// <summary>
        /// State of the entity. Could be used to check if an entity should update, render, collide, etc.
        /// </summary>
        bool Active { get; }

        /// <summary>
        /// Sets the entity's Active property to true.
        /// </summary>
        void Activate();

        /// <summary>
        /// Sets the entity's Active property to false.
        /// </summary>
        void Deactivate();
    }
}