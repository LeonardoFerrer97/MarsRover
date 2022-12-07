namespace MarsRover
{
    public struct Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate Move(Direction direction,Movement movement)
        {
            if(movement == Movement.Back)
            {
                direction = GoToOpositeDirection(direction);
            }
            if (direction.Equals(Direction.North))
            {
                return new Coordinate(X, Y + 1);
            }

            if (direction.Equals(Direction.East))
            {
                return new Coordinate(X + 1, Y);
            }

            if (direction.Equals(Direction.South))
            {
                return new Coordinate(X, Y - 1);
            }

            return new Coordinate(X - 1, Y);
        }

        public Direction GoToOpositeDirection(Direction direction)
        {
            if (direction.Equals(Direction.North))
            {
                return  Direction.South;
            }

            if (direction.Equals(Direction.East))
            {
                return Direction.West;
            }

            if (direction.Equals(Direction.South))
            {
                return Direction.North;
            }
            
            return Direction.East;
        }
    }
}