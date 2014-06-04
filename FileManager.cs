using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Labyrinth
{
    internal class FileManager
    {
        private const string FullFileName = "..\\..\\results.txt";
 
        internal FileManager()
        {
            TopResults.List.Changed += new ChangedTopResultsEventHandler(SaveToFile);
        }

        internal static void SaveToFile(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(sender.GetType());
            TextWriter writer = new StreamWriter(FileManager.FullFileName);
            ser.Serialize(writer, sender);
            writer.Close();
        }
    }
}
