using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Rover
    {
        /// <summary>
        /// Gets the rover position in the grid.
        /// </summary>
        public GridPoint position { get; private set; }

        /// <summary>
        /// Gets the direction the rover is facing.
        /// </summary>
        public Direction Heading { get; private set; }

        /// <summary>
        /// Intialize a new rover instance.
        /// </summary>
        /// <param name="startPt">The point on the grid where the rover will start.</param>
        /// <param name="startDirection">The direction the rover will be facing.</param>
        public Rover(GridPoint startPt, Direction startDirection)
        {
            this.position = startPt;
            this.Heading = startDirection;
            SendSuccessReport("was dropped on Mars");
        }

        /// <summary>
        /// Turn the rover to face the direction on the left of the current one.
        /// </summary>
        public void TurnLeft()
        {
            switch (this.Heading)
            {
                case Direction.North:
                    this.Heading = Direction.West;
                    break;
                case Direction.West:
                    this.Heading = Direction.South;
                    break;
                case Direction.South:
                    this.Heading = Direction.East;
                    break;
                case Direction.East:
                    this.Heading = Direction.North;
                    break;
                default:
                    throw new Exception("undefined heading!");
            }

            SendSuccessReport("turned left");
        }

        /// <summary>
        /// Turn the rover to face the direction on the right of the current one.
        /// </summary>
        public void TurnRight()
        {
            switch (this.Heading)
            {
                case Direction.North:
                    this.Heading = Direction.East;
                    break;
                case Direction.East:
                    this.Heading = Direction.South;
                    break;
                case Direction.South:
                    this.Heading = Direction.West;
                    break;
                case Direction.West:
                    this.Heading = Direction.North;
                    break;
                default:
                    throw new Exception("undefined heading!");
            }

            SendSuccessReport("turned right");
        }

        /// <summary>
        /// Move the rover forward toward the direction it is facing.
        /// </summary>
        public void MoveForward()
        {
            GridPoint nextPoint = position.GetNextForwardPoint(this.Heading);
            if (nextPoint.Equals(RoverProgram.obstacle))
            {
                throw new Exception($"Report: Obstacle encountered at {nextPoint}, aborting sequence!");
            }
            else
            {
                this.position = nextPoint;
            }

            SendSuccessReport("moved forward");
        }

        /// <summary>
        /// Move the rover backward away from the direction it is facing.
        /// </summary>
        public void MoveBackward()
        {
            GridPoint nextPoint = position.GetNextBackwardPoint(this.Heading);
            if (DetectObstacle(nextPoint))
            {
                throw new Exception($"Report: Obstacle encountered at {nextPoint}, aborting sequence!");
            }

            this.position = nextPoint;

            SendSuccessReport("moved backward");
        }

        /// <summary>
        /// Check if there is an obstacle in the next grid point.
        /// </summary>
        /// <param name="gridPoint">The GridPoint to evaluate.</param>
        /// <returns>A bool indicating an obstacle presence.</returns>
        public bool DetectObstacle(GridPoint gridPoint)
        {
            if (gridPoint.Equals(RoverProgram.obstacle))
            {
                return true;
            }

            return false;
        }

        public void SendSuccessReport(string action)
        {
            Console.WriteLine($"Report: I {action}, {this}");
        }

        public override string ToString()
        {
            return $"i'm at {position} and I'm facing the {Heading}!";
        }
    }
}
