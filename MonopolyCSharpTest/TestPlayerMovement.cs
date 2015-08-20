using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyCSharp;

namespace MonopolyCSharpTest
{
    [TestClass]
    public class TestPlayerMovement
    {
        private Game testGame;

        private const int TEST_PLAYER_ID = 1;

        [TestInitialize]
        public void Init()
        {
            testGame = new Game();

            testGame.CreatePlayer(TEST_PLAYER_ID, "testPlayer");
        }

        /// <summary>
        /// Tests a player's ability to move from location 0.
        /// Player on beginning location (numbered 0), rolls 7, ends up on location 7
        /// </summary>
        [TestMethod]
        public void TestPlayerMovementFromZero()
        {
            int testRoll = 7;

            testGame.MovePlayer(testGame.Players[TEST_PLAYER_ID], testRoll);

            Assert.AreEqual(7, testGame.Players[TEST_PLAYER_ID].Location);
        }

        /// <summary>
        /// Tests to see if player's location can exceed the number of spaces on the board.
        /// Player on location numbered 39, rolls 6, ends up on location 5
        /// </summary>
        [TestMethod]
        public void TestPlayerMovementWrapAround()
        {
            int testRoll = 6;

            testGame.MovePlayer(testGame.Players[TEST_PLAYER_ID], testRoll);

            Assert.AreEqual(5, testGame.Players[TEST_PLAYER_ID].Location);
        }
    }
}
