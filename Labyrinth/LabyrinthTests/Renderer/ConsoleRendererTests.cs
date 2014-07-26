namespace Labyrinth.Tests.Renderer
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Renderer;

    [TestClass]
    public class ConsoleRendererTests
    {
        ConsoleRenderer testRenderer = new ConsoleRenderer();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInitNegativeWidth()
        {
            int testHeight = 30;
            int testWidth = -5;

            testRenderer.Init(testWidth, testHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInitZeroWidth()
        {
            int testHeight = 30;
            int testWidth = 0;

            testRenderer.Init(testWidth, testHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInitTooHighWidth()
        {
            int testHeight = 30;
            int testWidth = 200;

            testRenderer.Init(testWidth, testHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInitNegativeHeight()
        {
            int testHeight = -5;
            int testWidth = 80;

            testRenderer.Init(testWidth, testHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInitZeroHeight()
        {
            int testHeight = 0;
            int testWidth = 80;

            testRenderer.Init(testWidth, testHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInitTooHighHeight()
        {
            int testHeight = 200;
            int testWidth = 80;

            testRenderer.Init(testWidth, testHeight);
        }
    }
}
