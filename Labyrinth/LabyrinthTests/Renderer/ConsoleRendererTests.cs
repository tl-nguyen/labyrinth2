namespace Labyrinth.Tests.Renderer
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using Labyrinth.Renderer.Contracts;
    using Labyrinth.Renderer;
    [TestClass]
    public class ConsoleRendererTests
    {/*
        LanguageStrings dialogStrings = new LanguageStrings();

        [TestMethod]
        public void TestWelcomeMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleRenderer renderer = new ConsoleRenderer();
                renderer.RenderWelcomeMessage();

                string expected = string.Format("{0}{1}", dialogStrings.GetDialog("Welcome"),
                    Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestExitMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleRenderer renderer = new ConsoleRenderer();
                renderer.RenderExitMessage();

                string expected = string.Format("{0}{1}", dialogStrings.GetDialog("GoodBye"),
                    Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestInvalidCommandMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleRenderer renderer = new ConsoleRenderer();
                renderer.RenderInvalidCommand();

                string expected = string.Format("{0}{1}", dialogStrings.GetDialog("InvalidCommand"),
                    Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestEnterNameForScoreBoardMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleRenderer renderer = new ConsoleRenderer();
                renderer.RenderEnterNameForScoreboard();

                string expected = string.Format("{0}{1}", dialogStrings.GetDialog("EnterName"),
                    Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestWinMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleRenderer renderer = new ConsoleRenderer();
                renderer.RenderWinMessage(0);
                string winMessage = dialogStrings.GetDialog("WinMessage").Replace("{","");
                winMessage = winMessage.Replace("}", "");
                string expected = string.Format("{0}{1}", winMessage, Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestInvalidMoveMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleRenderer renderer = new ConsoleRenderer();
                renderer.RenderInvalidMove();
                
                string expected = string.Format("{0}{1}", dialogStrings.GetDialog("InvalidMove"), 
                    Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }*/
    }
}
