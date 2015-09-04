using System;
using System.Collections.Generic;
using System.Security.Policy;
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

            Assert.AreEqual(false, testGame.Play());
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

            Assert.AreEqual(false, testGame.Play());
        }

        /// <summary>
        /// Tests to see if the player orders [Horse, Car] and [Car, Horse] occur within 100 game creations.
        /// </summary>
        [TestMethod]
        public void TestPlayerOrder()
        {
            // Player order {"Horse", "Car"}
            bool playerOrder1Detected = false;
            // Player order {"Car", "Horse"}
            bool playerOrder2Detected = false;

            for (int i = 0; i < 100; i++)
            {
                Game testGame = new Game(random);
                testGame.CreatePlayer(1, "Horse");
                testGame.CreatePlayer(2, "Car");

                testGame.DeterminePlayerOrder();

                if (testGame.PlayerOrderList[0].Name == "Horse" && testGame.PlayerOrderList[1].Name == "Car")
                {
                    playerOrder1Detected = true;
                }

                if (testGame.PlayerOrderList[0].Name == "Car" && testGame.PlayerOrderList[1].Name == "Horse")
                {
                    playerOrder2Detected = true;
                }
            }

            Assert.AreEqual(true, playerOrder1Detected);
            Assert.AreEqual(true, playerOrder2Detected);
        }
    }
}
