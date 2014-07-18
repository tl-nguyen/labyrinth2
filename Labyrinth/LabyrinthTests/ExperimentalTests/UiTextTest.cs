using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Labyrinth.experimental;

namespace Labyrinth.Tests.ExperimentalTests
{
    [TestClass]
    public class UiTextTest
    {
        [TestMethod]
        public void TestToString()
        {
            var textBox = new UiText(new IntPointX(0, 0), new ConsoleRendererX(), LabyrinthFactory.GetLanguageStringsInstance());
            var args = new string[] { "25" };
            textBox.SetText("WinMessage", args);
            Assert.AreEqual("Congratulations! You escaped in 25 moves.", textBox.ToString());
        }
    }
}
