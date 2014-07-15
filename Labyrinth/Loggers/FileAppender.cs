namespace Labyrinth.Loggers
{
    using System;
    using System.IO;

    public class FileAppender : IAppender
    {
        private ulong messageCount;
        private StreamWriter streamWriter;

        public FileAppender(string fileName)
        {
            if (fileName == string.Empty)
            {
                throw new ArgumentException("The inputed file name is empty or not a good format (/directory/file.name)");
            }

            this.streamWriter = File.CreateText(fileName);
            this.messageCount = 0;
        }

        public ulong MessageCount
        {
            get { return this.messageCount; }
        }

        public void AddMessage(string message)
        {
            this.messageCount++;
            this.streamWriter.WriteLine(message);
        }
    }
}