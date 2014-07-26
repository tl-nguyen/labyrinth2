using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Entities;
using Labyrinth.Renderer;

namespace Labyrinth.Tests.Entities
{
    [TestClass]
    public class GameConsoleTests
    {
        [TestMethod]
        public void TestGameConsoleAddInput()
        {
            var console = new GameConsole(new LanguageStrings());
            console.AddInput(Commons.Dialog.GoodBye);
            var actual = console.GetLastLines(1);
            string[] expected = {"Good Bye\nPress any key to exit...\n "};
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
        }

        [TestMethod]
        public void TestGameConsoleAddInputWithArgs()
        {
            var console = new GameConsole(new LanguageStrings());
            console.AddInput(Commons.Dialog.WinMessage, new string[]{"5"});
            var actual = console.GetLastLines(1);
            string[] expected = { "Congratulations! You escaped in 5 moves. " };
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
        }
    }
}
