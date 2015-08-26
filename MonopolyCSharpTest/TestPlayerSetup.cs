using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyCSharp;

namespace MonopolyCSharpTest
{
    [TestClass]
    public class TestPlayerSetup
    {
        private Game testGame;
        private Random random;
        private List<string> testPlayerNames;

        [TestInitialize]
        public void Init()
        {
            random = new Random();
            testGame = new Game(random);

            testPlayerNames = new List<string>()
            {
                "Horse",
                "Car"
            };
        }

        /// <summary>
        /// This test creates two players, named Horse and Car.
        /// If successful, the test will pass.
        /// </summary>
        [TestMethod]
        public void TestSuccessfulPlayerCreation()
        {
            for (int i = 0; i < testPlayerNames.Count; i++)
            {
                testGame.CreatePlayer(i + 1, testPlayerNames[i]);
            }

            Assert.AreEqual("Horse", testGame.Players[1].Name);
            Assert.AreEqual("Car", testGame.Players[2].Name);
        }

        /// <summary>
        /// Tests if a game is created with less than 2 players.
        /// A game with less than 2 players should fail to start.
        /// </summary>
        [TestMethod]
        public void TestGameWithLessThanTwoPlayers()
        {
            testGame.CreatePlayer(1, "testPlayer");

            Assert.AreEqual(false, testGame.Start());
        }

        /// <summary>
        /// Tests game creation with more than 8 players.
        /// A game with more than 8 players should fail to start.
        /// </summary>
        [TestMethod]
        public void TestGameWithGreaterThanEightPlayers()
        {
            for (int i = 1; i <= 9; i++)
            {
                testGame.CreatePlayer(i, $"testPlayer {i}");
            }

            Assert.AreEqual(false, testGame.Start());
        }
    }
}
