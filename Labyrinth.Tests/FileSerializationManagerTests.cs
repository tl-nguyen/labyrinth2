namespace Labyrinth.Tests
{
    using System;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Formatters.Soap;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFileSerializationManagerConstructorCreateInstanceNullFormatter()
        {
            var manager = new FileSerializationManager(null, "test.bin");
            Assert.IsInstanceOfType(manager, typeof(FileSerializationManager));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFileSerializationManagerConstructorCreateInstanceNullFileName()
        {
            var manager = new FileSerializationManager(new BinaryFormatter(), null);
            Assert.IsInstanceOfType(manager, typeof(FileSerializationManager));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFileSerializationManagerConstructorCreateInstanceEmptyFileName()
        {
            var manager = new FileSerializationManager(new BinaryFormatter(), string.Empty);
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
            var separator = "|";
            table.Add(new RatedResult(2, "player", new SeparatorResultFormatter(separator)));
            table.Add(new RatedResult(1, "player", new SeparatorResultFormatter(separator)));
            manager.Serialize(table);
            var afterSerializationTable = manager.Deserialize();
            Assert.AreEqual(table.ToString(), afterSerializationTable.ToString());
        }
    }
}
