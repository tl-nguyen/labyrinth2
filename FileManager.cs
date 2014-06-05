using System;
using System.IO;

namespace Labyrinth
{
    internal static class FileManager
    {
        private const string FullFileName = "..\\..\\results.txt";
 
        internal static void SaveToFile(object sender, EventArgs e)
        {
            var writer = new StreamWriter(FileManager.FullFileName);
            using (writer)
            {
                writer.Write(sender.ToString());
            }
        }

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
            catch(FileNotFoundException)
            {
                return string.Empty;
            }
        }
    }
}
