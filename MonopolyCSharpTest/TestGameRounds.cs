using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyCSharp;

namespace MonopolyCSharpTest
{
    [TestClass]
    public class TestGameRounds
    {
        private Monopoly testGame;
        private Random randomSeed;

        [TestInitialize]
        public void Init()
        {
            randomSeed = new Random();
            testGame = new Monopoly(randomSeed);
            
            testGame.CreatePlayers(new List<string>()
            {
                "Horse",
                "Car"
            });

            testGame.CreatePlayerOrder();
        }

        /// <summary>
        /// Test for making sure that each player gets a turn in a 20 round game.
        /// </summary>
        [TestMethod]
        public void TestPlayerTurns()
        {
            testGame.Play(20);

            foreach (Player player in testGame.PlayerList)
            {
                Assert.AreEqual(20, player.TurnsPlayed);
            }
        }

        /// <summary>
        /// Test to ensure that 20 rounds are played overall.
        /// </summary>
        [TestMethod]
        public void TestGameRoundsPlayed()
        {
            testGame.Play(20);

            Assert.AreEqual(20, testGame.RoundsPlayed);
        }
    }
}
