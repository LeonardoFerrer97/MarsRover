using MarsRover.Exceptions;

namespace MarsRover
{
    public class MarsRover
    {
        public string Position { get; }
        public Coordinate Coordinate { get; }
        public Direction Direction { get; }

        private MarsRover(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            Direction = direction;
            Position = $"{coordinate.X}-{coordinate.Y}-{direction}";
        }

        public override string ToString() => $"{Coordinate.X} {Coordinate.Y} {Direction}";

        public MarsRover Move(List<Movement> movements)
        {
            var newCoordinate = new Coordinate(Coordinate.X, Coordinate.Y);
            Direction newDirection = Direction;

            foreach (var movement in movements)
            {
                if (movement == Movement.Front || movement == Movement.Back)
                {
                    newCoordinate = newCoordinate.Move(newDirection, movement);

                    if (newCoordinate.X < 0 || newCoordinate.Y < 0)
                    {
                        throw new OutOfBoundsException(newCoordinate.X.ToString(),newCoordinate.Y.ToString());
                    }
                }
                else
                {
                    newDirection = movement == Movement.Left ? newDirection.TurnLeft() : newDirection.TurnRight();
                }
            }

            return new MarsRover(newCoordinate, newDirection);
        }

        public static MarsRover Create(string initialPosition)
        {
            var positions = initialPosition.Split(" ");

            if (!int.TryParse(positions[0], out var xPosition))
            {
                throw new InvalidPositionException(positions[0]);
            }

            if (!int.TryParse(positions[1], out var yPosition))
            {
                throw new InvalidPositionException(positions[1]);
            }

            return new MarsRover(new Coordinate(xPosition,yPosition), Direction.Create(positions[2]));
        }
    }
}
