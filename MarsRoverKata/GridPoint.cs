using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class GridPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public GridPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

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
                    throw new Exception("undefined heading!");
            }

            return new GridPoint(x, y);
        }

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
                    throw new Exception("undefined heading!");
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
