// ********************************
// <copyright file="PlainResultFormatter.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for plain result formatter.
    /// </summary>
    [Serializable]
    public class PlainResultFormatter : IResultFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlainResultFormatter"/> class.
        /// </summary>
        public PlainResultFormatter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlainResultFormatter"/> class, used for deserialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Serialization streaming context.</param>
        public PlainResultFormatter(SerializationInfo info, StreamingContext context)
        {
        }

        /// <summary>
        /// Formats the name of the player and the moves count of the game result.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="moves">Moves count.</param>
        /// <returns>String representing the formatted result.</returns>
        public string Format(string name, string moves)
        {
            return name + " --> " + moves + " moves";
        }

        /// <summary>
        /// Collects serialization data.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Serialization streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
