using System;

namespace MarsRoverKata
{
    public class RoverProgram
    {
        public static int GridSize;
        public static readonly GridPoint obstacle = new GridPoint(1,1);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello to the Rover command center");
            try
            {
                Rover rover = PutRoverOnMars();

                bool giveMoreInstructions = true;
                while (giveMoreInstructions)
                {
                    InstructRover(rover);

                    bool isCorrectInput = false;
                    do
                    {
                        Console.WriteLine($"Give more instructions? (y/n)");
                        string continueInstruction = Console.ReadLine();
                        switch (continueInstruction.ToLower())
                        {
                            case "y":
                                giveMoreInstructions = true;
                                isCorrectInput = true;
                                break;
                            case "n":
                                giveMoreInstructions = false;
                                isCorrectInput = true;
                                Console.WriteLine($"Sequence ended.");
                                break;
                            default:
                                Console.WriteLine("Not a valid answer (y/n)");
                                break;
                        }
                    } while (!isCorrectInput);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void InstructRover(Rover rover)
        {
            Console.WriteLine($"What is the command instruction? (exp: fflfbrfb)");
            string instructions = Console.ReadLine();

            ReadInstruction(rover, instructions);
        }

        public static void ReadInstruction(Rover rover, string instructions)
        {
            try
            {
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
            catch (ObstacleOnGridException obstacleException)
            {
                Console.WriteLine(obstacleException.Message);
            }
        }

        private static Rover PutRoverOnMars()
        {
            Console.WriteLine($"What is the planet grid size?");
            GridSize = int.Parse(Console.ReadLine());
            while (GridSize <= 0)
            {
                Console.WriteLine($"GridSize must be a positive integer");
                GridSize = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"What is the starting point X? (must be a positive integer under {GridSize + 1})");
            int x = int.Parse(Console.ReadLine());
            while (x > GridSize || x < 0)
            {
                Console.WriteLine($"X must be a positive integer under {GridSize + 1})");
                x = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"What is the starting point Y? (must be a positive integer under {GridSize + 1})");
            int y = int.Parse(Console.ReadLine());
            while (y > GridSize || y < 0)
            {
                Console.WriteLine($"Y must be a positive integer under {GridSize + 1})");
                y = int.Parse(Console.ReadLine());
            }


            Direction? startDirection = null;
            while (startDirection == null)
            {
                Console.WriteLine($"What is the starting point direction? (N, E, S, W)");
                string startDirectionName = Console.ReadLine();
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
                }
            }

            GridPoint startPt = new GridPoint(x, y);
            Rover rover = new Rover(startPt, startDirection.Value);
            return rover;
        }
    }
}
