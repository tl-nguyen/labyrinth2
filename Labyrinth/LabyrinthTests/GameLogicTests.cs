namespace Labyrinth.Tests
{
    using System;
    using Commons;
    using Labyrinth.Entities.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTestWithNull()
        {
            var actual = new GameLogic(null, null, null, null, null);
        }

        [TestMethod]
        public void UpdateWithExitTest()
        {
            var lab = new Mock<ILabyrinthPlayField>();
            lab.Setup(l => l.CurrentCell.Row).Returns(2);
            lab.Setup(l => l.CurrentCell.Col).Returns(2);
            lab.Setup(l => l.LabyrinthSize).Returns(5);

            var gameConsole = new Mock<IGameConsole>();

            var resultTable = new Mock<IResultsTable>();
            resultTable.Setup(r => r.Table.IsTopResult(It.IsAny<int>())).Returns(false);
            resultTable.Setup(r => r.Active).Returns(false);

            var input = new Mock<IUserInput>();
            input.Setup(i => i.GetInput()).Returns(Command.Exit);

            var factory = new Mock<IResultFactory>();
            GameLogic gameLogic = new GameLogic(lab.Object, gameConsole.Object, resultTable.Object, input.Object, factory.Object);
            gameLogic.Update();

            Assert.AreEqual(true, gameLogic.Exit);
        }

        [TestMethod]
        public void UpdateWithRestartTest()
        {
            var lab = new Mock<ILabyrinthPlayField>();
            lab.Setup(l => l.CurrentCell.Row).Returns(2);
            lab.Setup(l => l.CurrentCell.Col).Returns(2);
            lab.Setup(l => l.LabyrinthSize).Returns(5);
            lab.Setup(l => l.GenerateLabyrinth()).Verifiable();

            var gameConsole = new Mock<IGameConsole>();

            var resultTable = new Mock<IResultsTable>();
            resultTable.Setup(r => r.Table.IsTopResult(It.IsAny<int>())).Returns(false);
            resultTable.Setup(r => r.Active).Returns(false);

            var input = new Mock<IUserInput>();
            input.Setup(i => i.GetInput()).Returns(Command.Restart);

            var factory = new Mock<IResultFactory>();
            GameLogic gameLogic = new GameLogic(lab.Object, gameConsole.Object, resultTable.Object, input.Object, factory.Object);
            gameLogic.Update();

            lab.Verify(r => r.GenerateLabyrinth());
        }

        [TestMethod]
        public void UpdateWithTopWithActiveAsFalseTest()
        {
            var lab = new Mock<ILabyrinthPlayField>();
            lab.Setup(l => l.CurrentCell.Row).Returns(2);
            lab.Setup(l => l.CurrentCell.Col).Returns(2);
            lab.Setup(l => l.LabyrinthSize).Returns(5);
            lab.Setup(l => l.Deactivate()).Verifiable();

            var gameConsole = new Mock<IGameConsole>();

            var resultTable = new Mock<IResultsTable>();
            resultTable.Setup(r => r.Table.IsTopResult(It.IsAny<int>())).Returns(false);
            resultTable.Setup(r => r.Active).Returns(false);
            resultTable.Setup(r => r.Activate()).Verifiable();

            var input = new Mock<IUserInput>();
            input.Setup(i => i.GetInput()).Returns(Command.Top);

            var factory = new Mock<IResultFactory>();
            GameLogic gameLogic = new GameLogic(lab.Object, gameConsole.Object, resultTable.Object, input.Object, factory.Object);
            gameLogic.Update();

            resultTable.Verify(r => r.Activate());
            lab.Verify(l => l.Deactivate());
        }

        [TestMethod]
        public void UpdateWithTopWithActiveAsTrueTest()
        {
            var lab = new Mock<ILabyrinthPlayField>();
            lab.Setup(l => l.CurrentCell.Row).Returns(2);
            lab.Setup(l => l.CurrentCell.Col).Returns(2);
            lab.Setup(l => l.LabyrinthSize).Returns(5);
            lab.Setup(l => l.Activate()).Verifiable();

            var gameConsole = new Mock<IGameConsole>();

            var resultTable = new Mock<IResultsTable>();
            resultTable.Setup(r => r.Table.IsTopResult(It.IsAny<int>())).Returns(false);
            resultTable.Setup(r => r.Active).Returns(true);
            resultTable.Setup(r => r.Deactivate()).Verifiable();

            var input = new Mock<IUserInput>();
            input.Setup(i => i.GetInput()).Returns(Command.Top);

            var factory = new Mock<IResultFactory>();
            GameLogic gameLogic = new GameLogic(lab.Object, gameConsole.Object, resultTable.Object, input.Object, factory.Object);
            gameLogic.Update();

            resultTable.Verify(r => r.Deactivate());
            lab.Verify(l => l.Activate());
        }

        [TestMethod]
        public void UpdateWithEdgeOfMatrixTest()
        {
            var lab = new Mock<ILabyrinthPlayField>();
            lab.Setup(l => l.CurrentCell.Row).Returns(0);
            lab.Setup(l => l.CurrentCell.Col).Returns(2);
            lab.Setup(l => l.LabyrinthSize).Returns(5);
            lab.Setup(l => l.GenerateLabyrinth()).Verifiable();

            var gameConsole = new Mock<IGameConsole>();
            gameConsole.Setup(g => g.AddInput(It.IsAny<Dialog>())).Verifiable();

            var resultTable = new Mock<IResultsTable>();
            resultTable.Setup(r => r.Table.IsTopResult(It.IsAny<int>())).Returns(false);
            resultTable.Setup(r => r.Active).Returns(false);

            var input = new Mock<IUserInput>();
            input.Setup(i => i.GetInput()).Returns(Command.Top);

            var factory = new Mock<IResultFactory>();
            GameLogic gameLogic = new GameLogic(lab.Object, gameConsole.Object, resultTable.Object, input.Object, factory.Object);
            gameLogic.Update();

            lab.Verify(l => l.GenerateLabyrinth());
        }
    }
}
