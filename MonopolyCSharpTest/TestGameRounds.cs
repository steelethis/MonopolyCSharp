using System;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyCSharp;

namespace MonopolyCSharpTest
{
    [TestClass]
    public class TestGameRounds
    {
        private Random random;
        private Game testGame;

        [TestInitialize]
        public void Init()
        {
            random = new Random();
            testGame = new Game(random);

            testGame.CreatePlayer(0, "Horse");
            testGame.CreatePlayer(1, "Car");

            testGame.DeterminePlayerOrder();
        }

        /// <summary>
        /// Tests that game can go for 20 rounds successfully.
        /// Also tests to ensure that each player got to play 20 rounds.
        /// </summary>
        [TestMethod]
        public void TestSuccessfulGame()
        {
            testGame.Start();

            Assert.AreEqual(20, testGame.RoundsPerPlayer[0]);
            Assert.AreEqual(20, testGame.RoundsPerPlayer[1]);
            Assert.AreEqual(20, testGame.RoundsPlayed);
        }
    }
}
