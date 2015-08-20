using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyCSharp;

namespace MonopolyCSharpTest
{
    [TestClass]
    public class TestMonopolyPlayers
    {
        private Monopoly testGame;
        private Random testRandom;

        [TestInitialize]
        public void Init()
        {
            testRandom = new Random();
            testGame = new Monopoly(testRandom);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidNumberOfPlayers()
        {
            testGame.CreatePlayers(new List<string>()
            {
                "Horse"
            });
        }

        [TestMethod]
        public void TestPlayerCreation()
        {
            List<string> playerCreationList = new List<string>()
            {
                "Horse",
                "Car"
            };

            testGame.CreatePlayers(playerCreationList);

            Assert.AreEqual(playerCreationList[0], testGame.PlayerList[0].Name);
            Assert.AreEqual(playerCreationList[1], testGame.PlayerList[1].Name);
        }


        /// <summary>
        /// Tests the random player order.
        /// </summary> 
        // Originally this test failed because I was recreating the random seed 100 times.
        // This ended up causing the test to compare different player orders that were generated with different seeds,
        // resulting in instances where the first player never changed over the course of 100 game creations.
        [TestMethod]
        public void TestPlayerOrder()
        {
            string lastPlayerOne = "";
            bool orderChanged = false;

            for (int i = 0; i < 100; i++)
            {
                testGame = new Monopoly(testRandom);
                testGame.CreatePlayers(new List<string>()
                {
                    "Horse",
                    "Car"
                });

                testGame.CreatePlayerOrder();

                if (!string.IsNullOrEmpty(lastPlayerOne) && lastPlayerOne != testGame.PlayerQueue.Peek().Name)
                {
                    orderChanged = true;
                }

                lastPlayerOne = testGame.PlayerQueue.Peek().Name;
            }

            Assert.AreEqual(true, orderChanged);
        }
    }
}
