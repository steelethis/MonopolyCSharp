using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyCSharp;

namespace MonopolyCSharpTest
{
    [TestClass]
    public class TestPlayerMovement
    {
        private Player testPlayer;
        private Monopoly testGame;

        [TestInitialize]
        public void Init()
        {
            testGame = new Monopoly();
            testPlayer = new Player(testGame, "Hat");
        }

        /// <summary>
        /// Location should equal whatever is passed.
        /// </summary>
        [TestMethod]
        public void TestPlayerUpdateLocation()
        {
            testPlayer.UpdateLocation(5);

            Assert.AreEqual(5, testPlayer.Location);
        }

        /// <summary>
        /// Player beginning on location 0 and rolls a 7 should end up on location 7 on the board.
        /// </summary>
        [TestMethod]
        public void TestPlayerMovementFromZero()
        {
            testPlayer.UpdateLocation(0);

            testPlayer.Move(7);

            Assert.AreEqual(7, testPlayer.Location);
        }

        /// <summary>
        /// Player on location 39 that rolls a 6 should end up on location 5 on board.
        /// </summary>
        [TestMethod]
        public void TestPlayerMovementEndOfBoard()
        {
            testPlayer.UpdateLocation(39);

            testPlayer.Move(6);

            Assert.AreEqual(5, testPlayer.Location);
        }
    }
}
