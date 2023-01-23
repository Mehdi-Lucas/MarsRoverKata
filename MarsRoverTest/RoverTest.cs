using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverKata;
using System;

namespace MarsRoverKataTest
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void TestMoveForwardNorth()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.North);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(4,5), rover.position);
        }

        [TestMethod]
        public void TestMoveForwardSouth()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.South);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(4, 3), rover.position);
        }

        [TestMethod]
        public void TestMoveForwardEast()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.East);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(5, 4), rover.position);
        }

        [TestMethod]
        public void TestMoveForwardWest()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.West);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(3, 4), rover.position);
        }

        [TestMethod]
        public void TestMoveBackwardNorth()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.North);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(4, 3), rover.position);
        }

        [TestMethod]
        public void TestMoveBackWardSouth()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.South);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(4, 5), rover.position);
        }

        [TestMethod]
        public void TestMoveBackwardEast()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.East);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(3, 4), rover.position);
        }

        [TestMethod]
        public void TestMoveBackwardWest()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.West);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(5, 4), rover.position);
        }

        [TestMethod]
        public void TestTurnRight()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.North);
            rover.TurnRight();
            Assert.AreEqual(Direction.East, rover.Heading);
            rover.TurnRight();
            Assert.AreEqual(Direction.South, rover.Heading);
            rover.TurnRight();
            Assert.AreEqual(Direction.West, rover.Heading);
            rover.TurnRight();
            Assert.AreEqual(Direction.North, rover.Heading);
        }

        [TestMethod]
        public void TestTurnLeft()
        {
            Rover rover = new Rover(new GridPoint(4, 4), Direction.North);
            rover.TurnLeft();
            Assert.AreEqual(Direction.West, rover.Heading);
            rover.TurnLeft();
            Assert.AreEqual(Direction.South, rover.Heading);
            rover.TurnLeft();
            Assert.AreEqual(Direction.East, rover.Heading);
            rover.TurnLeft();
            Assert.AreEqual(Direction.North, rover.Heading);
        }

        [TestMethod]
        public void TestForwardWrapping()
        {
            Rover rover = new Rover(new GridPoint(4, 8), Direction.North);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(4, 0), rover.position);

            rover = new Rover(new GridPoint(8, 4), Direction.East);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(0, 4), rover.position);

            rover = new Rover(new GridPoint(0, 4), Direction.West);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(8, 4), rover.position);

            rover = new Rover(new GridPoint(4, 0), Direction.South);
            rover.MoveForward();
            Assert.AreEqual(new GridPoint(4, 8), rover.position);
        }

        [TestMethod]
        public void TestBackwardWrapping()
        {
            Rover rover = new Rover(new GridPoint(4, 0), Direction.North);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(4, 8), rover.position);

            rover = new Rover(new GridPoint(0, 4), Direction.East);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(8, 4), rover.position);

            rover = new Rover(new GridPoint(8, 4), Direction.West);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(0, 4), rover.position);

            rover = new Rover(new GridPoint(4, 8), Direction.South);
            rover.MoveBackward();
            Assert.AreEqual(new GridPoint(4, 0), rover.position);
        }

        [TestMethod]
        public void TestObstacleDetection()
        {
            Rover rover = new Rover(new GridPoint(1, 0), Direction.North);
            try
            {
                rover.MoveForward();
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }
    }
}
