// ********************************
// <copyright file="FileManager.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    using System;
    using System.IO;

    /// <summary>
    /// Static class for IO operations with files
    /// </summary>
    internal static class FileManager
    {
        /// <summary>
        /// File name and path of the file which will be read/written.
        /// </summary>
        private const string FullFileName = "..\\..\\results.txt";
 
        /// <summary>
        /// Saves an object to file using its ToString() implementation.
        /// </summary>
        /// <param name="sender">Object to save.</param>
        /// <param name="e">Event arguments.</param>
        internal static void SaveToFile(object sender, EventArgs e)
        {
            var writer = new StreamWriter(FileManager.FullFileName);
            using (writer)
            {
                writer.Write(sender.ToString());
            }
        }

        /// <summary>
        /// Reads the specified file.
        /// </summary>
        /// <returns>String holding the all content of the file.</returns>
        internal static string LoadFromFile()
        {
            try
            {
                var reader = new StreamReader(FileManager.FullFileName);
                using (reader)
                {
                    return reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return string.Empty;
            }
        }
    }
}
