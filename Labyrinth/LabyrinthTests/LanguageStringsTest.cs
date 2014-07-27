namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Renderer;
    using Labyrinth.Commons;

    [TestClass]
    public class LanguageStringsTest
    {
        LanguageStrings testDialogList = new LanguageStrings();

        [TestMethod]
        public void TestGetDialogCorrectKey()
        {
            string actualString = testDialogList.GetDialog(Dialog.Welcome);
            string expectedString = "Welcome to “Labyrinth” game. Please try to escape. Use 't' to toogle between the top scoreboard menu and game, 'r' to start a new game and 'e' to quit the game.";
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
