using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class GridPoint
    {
        /// <summary>
        /// Gets the X coord of this GridPoint.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Gets the Y coord of this GridPoint.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Initialize a new instance of a GridPoint.
        /// </summary>
        /// <param name="x">The point X coord.</param>
        /// <param name="y">The point Y coord.</param>
        public GridPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the next GridPoint when moving forward in a specific direction.
        /// </summary>
        /// <param name="direction">A Direction to move toward to.</param>
        /// <returns>The next forward GridPoint.</returns>
        public GridPoint GetNextForwardPoint(Direction direction)
        {
            int x = this.X;
            int y = this.Y;
            switch (direction)
            {
                case Direction.North:
                    y = this.Y < RoverProgram.GridSize ? Y + 1 : 0;
                    break;
                case Direction.East:
                    x = this.X < RoverProgram.GridSize ? X + 1 : 0;
                    break;
                case Direction.South:
                    y = this.Y > 0 ? Y - 1:  RoverProgram.GridSize;
                    break;
                case Direction.West:
                    x = this.X > 0 ? X - 1 : RoverProgram.GridSize;
                    break;
                default:
                    throw new ArgumentException($"undefined heading {direction}!");
            }

            return new GridPoint(x, y);
        }

        /// <summary>
        /// Gets the next GridPoint when moving backward from a specific direction.
        /// </summary>
        /// <param name="direction">A Direction to move away from.</param>
        /// <returns>The next backward GridPoint.</returns>

        public GridPoint GetNextBackwardPoint(Direction direction)
        {
            int x = this.X;
            int y = this.Y;
            switch (direction)
            {
                case Direction.North:
                    y = this.Y > 0 ? Y - 1 : RoverProgram.GridSize;
                    break;
                case Direction.East:
                    x = this.X > 0 ? X - 1 : RoverProgram.GridSize;
                    break;
                case Direction.South:
                    y = this.Y < RoverProgram.GridSize ? Y + 1 : 0;
                    break;
                case Direction.West:
                    x = this.X < RoverProgram.GridSize ? X + 1 : 0;
                    break;
                default:
                    throw new ArgumentException($"undefined heading {direction}!");
            }

            return new GridPoint(x, y);
        }

        public override bool Equals(object other)
        {
            GridPoint otherGridPoint = other as GridPoint;
            return otherGridPoint != null && this.X == otherGridPoint.X && this.Y == otherGridPoint.Y;
        }

        public override string ToString()
        {
            return $"X: {this.X}, Y: {this.Y}";
        }
    }
}
