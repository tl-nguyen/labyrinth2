// ********************************
// <copyright file="SeparatorResultFormatter.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for result formatter with specified separator.
    /// </summary>
    [Serializable]
    public class SeparatorResultFormatter : IResultFormatter
    {
        /// <summary>
        /// Separator used for formatting.
        /// </summary>
        private string separator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeparatorResultFormatter"/> class.
        /// </summary>
        /// <param name="stringSeparator">String separator used for formatting.</param>
        public SeparatorResultFormatter(string stringSeparator)
        {
            if (stringSeparator != null)
            {
                this.separator = stringSeparator;
            }
            else
            {
                throw new ArgumentNullException("The separator could not be null!");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeparatorResultFormatter"/> class, used for deserialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Serialization streaming context.</param>
        public SeparatorResultFormatter(SerializationInfo info, StreamingContext context)
        {
            this.separator = (string)info.GetValue("separator", typeof(string));
        }

        /// <summary>
        /// Formats the name of the player and the moves count of the game result.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="moves">Moves count.</param>
        /// <returns>String representing the formatted result.</returns>
        public string Format(string name, string moves)
        {
            return string.Format("{2} {0} {2} {1} moves", name, moves, this.separator);
        }

        /// <summary>
        /// Collects serialization data.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Serialization streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("separator", this.separator);
        }
    }
}
