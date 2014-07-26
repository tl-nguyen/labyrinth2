namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Renderer;

    [TestClass]
    public class LanguageStringsTest
    {
        LanguageStrings testDialogList = new LanguageStrings();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetDialogError()
        {
            string testString = testDialogList.GetDialog("wrongKey");
        }

        [TestMethod]
        public void TestGetDialogCorrectKey()
        {
            string actualString = testDialogList.GetDialog("Welcome");
            string expectedString = "Welcome to “Labyrinth” game. Please try to escape. Use 't' to view the top scoreboard, 'r' to start a new game and 'e' to quit the game.";
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
