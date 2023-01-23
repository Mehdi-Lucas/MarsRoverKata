using System;

namespace MarsRoverKata
{
    internal class RoverProgram
    {
        public static readonly int GridSize = 8;
        public static readonly GridPoint obstacle = new GridPoint(1,1);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello to the Rover command center");
            try
            {
                Console.WriteLine($"What is the starting point X? (must be a positive integer under {GridSize})");
                int x = int.Parse(Console.ReadLine());
                if (x > GridSize || x < 0)
                {
                    throw new ArgumentException($"X is not valid");
                }

                Console.WriteLine($"What is the starting point Y? (must be a positive integer under {GridSize})");
                int y = int.Parse(Console.ReadLine());
                if (y > GridSize || y < 0)
                {
                    throw new ArgumentException($"Y is not valid");
                }

                Console.WriteLine($"What is the starting point direction?");
                string startDirectionName = Console.ReadLine();
                Direction startDirection = Direction.North;
                switch (startDirectionName.ToLower())
                {
                    case "n":
                        startDirection = Direction.North;
                        break;
                    case "s":
                        startDirection = Direction.South;
                        break;
                    case "e":
                        startDirection = Direction.East;
                        break;
                    case "w":
                        startDirection = Direction.West;
                        break;
                    default:
                        throw new ArgumentException($"unknow direction! {startDirectionName}");
                }

                Console.WriteLine($"What is the command instruction? (exp: fflfbrfb)");

                GridPoint startPt = new GridPoint(x, y);
                Rover rover = new Rover(startPt, startDirection);
                string instructions = Console.ReadLine();

                foreach (char instruction in instructions.ToLower())
                {
                    switch (instruction)
                    {
                        case 'f':
                            rover.MoveForward();
                            break;
                        case 'b':
                            rover.MoveBackward();
                            break;
                        case 'l':
                            rover.TurnLeft();
                            break;
                        case 'r':
                            rover.TurnRight();
                            break;
                        default:
                            throw new ArgumentException($"unknow instruction! {instruction}");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
