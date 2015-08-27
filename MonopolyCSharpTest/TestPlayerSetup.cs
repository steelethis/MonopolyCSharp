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

        /// <summary>
        /// Tests player order creation.
        /// Create a game with two players named Horse and Car. 
        /// Within creating 100 games, both orders [Horse, Car] and [car, horse] occur.
        /// 
        /// This test is to determine if the player order [Horse, Car] shows up in 100 game creations.
        /// </summary>
        [TestMethod]
        public void TestPlayerOrder1()
        {
            bool expectedOrderDetected = false;

            for (int i = 0; i < 100; i++)
            {
                testGame = new Game(random);

                testGame.CreatePlayer(1, "Horse");
                testGame.CreatePlayer(2, "Car");

                testGame.DeterminePlayerOrder();

                if (testGame.PlayerOrderList[0].Name == "Horse" && testGame.PlayerOrderList[1].Name == "Car")
                {
                    expectedOrderDetected = true;
                }
            }

            Assert.AreEqual(true, expectedOrderDetected);
        }

        /// <summary>
        /// Tests player order creation.
        /// Create a game with two players named Horse and Car. 
        /// Within creating 100 games, both orders [Horse, Car] and [car, horse] occur.
        /// 
        /// This test is to determine if the player order [Car, Horse] shows up in 100 game creations.
        /// </summary>
        [TestMethod]
        public void TestPlayerOrder2()
        {
            bool expectedOrderDetected = false;

            for (int i = 0; i < 100; i++)
            {
                testGame = new Game(random);

                testGame.CreatePlayer(1, "Horse");
                testGame.CreatePlayer(2, "Car");

                testGame.DeterminePlayerOrder();

                if (testGame.PlayerOrderList[0].Name == "Car" && testGame.PlayerOrderList[1].Name == "Horse")
                {
                    expectedOrderDetected = true;
                }
            }

            Assert.AreEqual(true, expectedOrderDetected);
        }
    }
}
