// ********************************
// <copyright file="FileSerializationManager.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Results
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for serialization of data in a file
    /// </summary>
    public class FileSerializationManager
    {
        /// <summary>
        /// Field for the formatter used for serialization.
        /// </summary>
        private IFormatter formatter;

        /// <summary>
        /// Field for the filename of the serialized data.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSerializationManager"/> class.
        /// </summary>
        /// <param name="formatter">Formatter for serialization.</param>
        /// <param name="fileName">File name of the result serialized file.</param>
        public FileSerializationManager(IFormatter formatter, string fileName)
        {
            this.Formatter = formatter;
            this.FileName = fileName;
        }

        /// <summary>
        /// Gets the formatter used for serialization.
        /// </summary>
        public IFormatter Formatter
        {
            get
            {
                return this.formatter;
            }

            private set
            {
                if (value != null)
                {
                    this.formatter = value;
                }
                else
                {
                    throw new ArgumentNullException("The formatter for serialization could not be null!");
                }
            }
        }

        /// <summary>
        /// Gets the filename of the serialized data.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }

            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.fileName = value;
                }
                else
                {
                    throw new ArgumentException("The file name have to be specified!");
                }
            }
        }

        /// <summary>
        /// Serializes the object in a specified file using the specified formatter.
        /// </summary>
        /// <param name="data">Object for serialization.</param>
        public void Serialize(object data)
        {
            var stream = new FileStream(this.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            this.Formatter.Serialize(stream, data);
            stream.Close();
        }

        /// <summary>
        /// Deserializes the data from a specified file using the specified formatter.
        /// </summary>
        /// <returns>Deserialized object.</returns>
        public object Deserialize()
        {
            var stream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var deserializedObject = this.Formatter.Deserialize(stream);
            stream.Close();
            return deserializedObject;
        }
    }
}