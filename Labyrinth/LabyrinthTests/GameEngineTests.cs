namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Labyrinth.LabyrinthHandler.Contracts;
    using Labyrinth.Entities.Contracts;
    using Labyrinth.Results;
    using System.Runtime.Serialization;

    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestWithZeroWidth()
        {
            var fakeFactory = new Mock<IFactory>();
            var actual = new GameEngine(0, 100, fakeFactory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestWithZeroHeight()
        {
            var fakeFactory = new Mock<IFactory>();
            var actual = new GameEngine(110, 0, fakeFactory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestWithNegativeHeight()
        {
            var fakeFactory = new Mock<IFactory>();
            var actual = new GameEngine(110, -1, fakeFactory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestWithNegativeWidth()
        {
            var fakeFactory = new Mock<IFactory>();
            var actual = new GameEngine(-1, 100, fakeFactory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTestWithNullIFactory()
        {
            var actual = new GameEngine(100, 100, null);
        }
    }
}
