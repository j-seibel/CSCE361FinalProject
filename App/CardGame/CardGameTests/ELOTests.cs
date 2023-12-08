using CardGame.Models;
using System;

namespace CardGameTests
{
    [TestClass]
    public class ELOTests
    {
        [TestMethod]
        public void TestELOValid()
        {
            Player p = new Player("TestName", "TestRoom", 1000);
            p.updateElo(1100, 1);
            Assert.IsTrue(p.ELO -  1003.6 < 0.1);

        }

        [TestMethod]
        public void TestELOInvalid()
        {
            Player p = new Player("TestName", "TestRoom", 1000);
            Assert.ThrowsException<ArgumentException>(() => p.updateElo(-1000, 0));


        }

        [TestMethod]

        public void TestRatingInvalid()
        {
            Player p = new Player("TestName", "TestRoom", 1000);
            Assert.ThrowsException<ArgumentException>(() => p.updateElo(1000, -2));

        }

        [TestMethod]
        public void TestELOValidWin()
        {
            // Arrange
            Player p = new Player("TestName", "TestRoom", 1200);

            // Act
            p.updateElo(1400, 1);

            // Assert
            Assert.IsTrue(Math.Abs(p.ELO - 1216.4) < 0.1);
        }

        [TestMethod]
        public void TestELOValidLoss()
        {
            // Arrange
            Player p = new Player("TestName", "TestRoom", 1200);

            // Act
            p.updateElo(1000, 0);

            // Assert
            Assert.IsTrue(Math.Abs(p.ELO - 1183.6) < 0.1);
        }

        [TestMethod]
        public void TestELOInvalidNegativeEloChange()
        {
            // Arrange
            Player p = new Player("TestName", "TestRoom", 1000);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => p.updateElo(-100, 1));
        }

        [TestMethod]
        public void TestELOInvalidNegativeGamesPlayed()
        {
            // Arrange
            Player p = new Player("TestName", "TestRoom", 1000);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => p.updateElo(100, -2));
        }
    }
}