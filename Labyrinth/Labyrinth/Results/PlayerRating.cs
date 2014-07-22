// ********************************
// <copyright file="PlayerRating.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Results
{
    /// <summary>
    /// Enumeration used for player's ratings in the players results
    /// </summary>
    public enum PlayerRating
    {
        /// <summary>
        /// Master rating less or equal to 4 move counts.
        /// </summary>
        Master = 4,

        /// <summary>
        /// Player rating less or equal to 6 move counts.
        /// </summary>
        Player = 6,

        /// <summary>
        /// Beginner rating greater than 6 move counts.
        /// </summary>
        Beginner = 9
    }
}