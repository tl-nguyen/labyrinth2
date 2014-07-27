// ********************************
// <copyright file="FileAppender.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Loggers
{
    using System;
    using System.IO;
    using Contracts;

    /// <summary>
    /// This class is a plugin for loggers. It write data to a file.
    /// </summary>
    public class FileAppender : IAppender
    {
        private ulong messageCount;
        private string fileName;

        /// <summary>
        /// This method initialize a new instance of the file appender
        /// </summary>
        /// <param name="fileName">The name of a file to write</param>
        public FileAppender(string fileName)
        {
            if (fileName == string.Empty)
            {
                throw new ArgumentException("The inputed file name is empty or not a good format (ex. /directory/file.name)");
            }

            using (StreamWriter streamWriter = new StreamWriter(fileName, false))
            {
            }

            this.fileName = fileName;
            this.messageCount = 0;
        }

        /// <summary>
        /// Returns a number of currently logged messages
        /// </summary>
        public ulong MessageCount
        {
            get { return this.messageCount; }
        }

        /// <summary>
        /// Add a passed message to the file
        /// </summary>
        /// <param name="message">Message to be store in a file</param>
        public void AddMessage(string message)
        {
            this.messageCount++;

            using (StreamWriter streamWriter = new StreamWriter(this.fileName, true))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}