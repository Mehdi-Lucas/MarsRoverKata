using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Rover
    {
        public GridPoint position { get; private set; }
        public Direction Heading { get; private set; }

        public Rover(GridPoint startPt, Direction startDirection)
        {
            this.position = startPt;
            this.Heading = startDirection;
            Console.WriteLine(this);
        }

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

            Console.WriteLine($"Report: I turned left and now I'm facing the {Heading}!");
        }

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

            Console.WriteLine($"Report: I turned right and now I'm facing the {Heading}!");
        }

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

            Console.WriteLine(this);
        }

        public void MoveBackward()
        {
            GridPoint nextPoint = position.GetNextBackwardPoint(this.Heading);
            if (nextPoint.Equals(RoverProgram.obstacle))
            {
                throw new Exception($"Report: Obstacle encountered at {nextPoint}, aborting sequence!");
            }
            else
            {
                this.position = nextPoint;
            }

            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Report: i'm at {position} and I'm facing the {Heading}!";
        }
    }
}
