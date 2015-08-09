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

        [TestInitialize]
        public void Init()
        {
            testGame = new Monopoly();
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

        [TestMethod]
        public void TestPlayerOrder()
        {
            string lastPlayerOne = "";
            bool orderChanged = false;

            for (int i = 0; i < 100; i++)
            {
                testGame = new Monopoly();
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
