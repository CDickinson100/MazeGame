using System;
using MazeGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MovingUpFailsWhenThereIsNoUpPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.up = false;
            player.moveUp();
            Assert.AreEqual(player.x, 0);
            Assert.AreEqual(player.z, 0);
        }
        [TestMethod]
        public void MovingUpSucceedsWhenThereIsAnUpPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.up = true;
            player.moveUp();
            Assert.AreEqual(player.x, 0);
            Assert.AreEqual(player.z, -1);
        }
        [TestMethod]
        public void MovingDownFailsWhenThereIsNoDownPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.down = false;
            player.moveDown();
            Assert.AreEqual(player.x, 0);
            Assert.AreEqual(player.z, 0);
        }
        [TestMethod]
        public void MovingDownSucceedsWhenThereIsAnDownPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.down = true;
            player.moveDown();
            Assert.AreEqual(player.x, 0);
            Assert.AreEqual(player.z, 1);
        }
        [TestMethod]
        public void MovingLeftFailsWhenThereIsNoLeftPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.left = false;
            player.moveLeft();
            Assert.AreEqual(player.x, 0);
            Assert.AreEqual(player.z, 0);
        }
        [TestMethod]
        public void MovingLeftSucceedsWhenThereIsAnLeftPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.left = true;
            player.moveLeft();
            Assert.AreEqual(player.x, -1);
            Assert.AreEqual(player.z, 0);
        }
        [TestMethod]
        public void MovingRightFailsWhenThereIsNoRightPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.right = false;
            player.moveRight();
            Assert.AreEqual(player.x, 0);
            Assert.AreEqual(player.z, 0);
        }
        [TestMethod]
        public void MovingRightSucceedsWhenThereIsAnRightPath()
        {
            Player player = new Player();
            Cell current = player.maze.getCell(0, 0);
            current.right = true;
            player.moveRight();
            Assert.AreEqual(player.x, 1);
            Assert.AreEqual(player.z, 0);
        }
    }
}
