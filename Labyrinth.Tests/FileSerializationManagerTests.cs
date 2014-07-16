namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Formatters.Soap;

    [TestClass]
    public class FileSerializationManagerTests
    {
        [TestMethod]
        public void TestFileSerializationManagerConstructorCreateInstance()
        {
            var manager = new FileSerializationManager(new BinaryFormatter(), "test.bin");
            Assert.IsInstanceOfType(manager, typeof(FileSerializationManager));
        }

        [TestMethod]
        public void TestFileSerializationManagerGetFileName()
        {
            var manager = new FileSerializationManager(new BinaryFormatter(), "test.bin");
            Assert.AreEqual(manager.FileName, "test.bin");
        }

        [TestMethod]
        public void TestFileSerializationManagerGetFormatter()
        {
            var soapFormatter = new SoapFormatter();
            var manager = new FileSerializationManager(soapFormatter, "test.bin");  
            Assert.AreEqual(manager.Formatter, soapFormatter);
        }

        [TestMethod]
        public void TestFileSerializationManagerSerializeDeserializeSimpleResult()
        {
            var manager = new FileSerializationManager(new BinaryFormatter(), "test.bin");
            var table = new TopResults();
            table.Add(new SimpleResult(2, "player", new PlainResultFormatter()));
            table.Add(new SimpleResult(1, "player", new PlainResultFormatter()));
            manager.Serialize(table);
            var afterSerializationTable = manager.Deserialize();
            Assert.AreEqual(table.ToString(), afterSerializationTable.ToString());
        }

        [TestMethod]
        public void TestFileSerializationManagerSerializeDeserializeRatedResult()
        {
            var manager = new FileSerializationManager(new BinaryFormatter(), "test.bin");
            var table = new TopResults();
            table.Add(new RatedResult(2, "player", new SeparatorResultFormatter("|")));
            table.Add(new RatedResult(1, "player", new SeparatorResultFormatter("|")));
            manager.Serialize(table);
            var afterSerializationTable = manager.Deserialize();
            Assert.AreEqual(table.ToString(), afterSerializationTable.ToString());
        }
    }
}
