namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var labyrinth = LabyrinthFactory.GetLabyrinthInstance();
        }
    }
}
