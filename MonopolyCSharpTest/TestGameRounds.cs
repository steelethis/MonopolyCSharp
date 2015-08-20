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
            Dictionary<Player, int> turnsPerPlayer = new Dictionary<Player, int>();
        }
    }
}
