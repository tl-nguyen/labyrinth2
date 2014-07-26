namespace Labyrinth.Tests.LabyrinthHandler
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.LabyrinthHandler;
    using Labyrinth.LabyrinthHandler.Contracts;
    using Labyrinth.Entities.Contracts;
    using Labyrinth.Commons;

    [TestClass]
    public class MoveHandlerTests
    {
        [TestMethod]
        public void MoveToTheWallShouldBeInvalid()
        {
            IMoveHandler moveHandler = new MoveHandler();
            ILabyrinthPlayField labyrinth = new MockLabyrinth();
            bool result;

            result = moveHandler.MoveAction(labyrinth, Command.Down);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MoveToEmptyCellShouldBeValid()
        {
            IMoveHandler moveHandler = new MoveHandler();
            ILabyrinthPlayField labyrinth = new MockLabyrinth();
            bool result;

            result = moveHandler.MoveAction(labyrinth, Command.Up);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExitFoundWhenPlayerReachedLabyrinthBorder()
        {
            IMoveHandler moveHandler = new MoveHandler();
            ILabyrinthPlayField labyrinth = new MockLabyrinth();

            moveHandler.MoveAction(labyrinth, Command.Right);

            Assert.IsTrue(moveHandler.ExitFound(labyrinth, labyrinth.CurrentCell));
        }

        [TestMethod]
        public void ExitNotFoundWhenPlayerNotReachedLabyrinthBorder()
        {
            IMoveHandler moveHandler = new MoveHandler();
            ILabyrinthPlayField labyrinth = new MockLabyrinth();

            Assert.IsFalse(moveHandler.ExitFound(labyrinth, labyrinth.CurrentCell));
        }
    }
}
