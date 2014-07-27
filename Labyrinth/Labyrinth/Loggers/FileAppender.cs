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

    public class FileAppender : IAppender
    {
        private ulong messageCount;
        private string fileName;

        public FileAppender(string fileName)
        {
            if (fileName == string.Empty)
            {
                throw new ArgumentException("The inputed file name is empty or not a good format (/directory/file.name)");
            }

            using (StreamWriter streamWriter = new StreamWriter(fileName, false))
            {

            };

            this.fileName = fileName;
            this.messageCount = 0;
        }

        public ulong MessageCount
        {
            get { return this.messageCount; }
        }

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