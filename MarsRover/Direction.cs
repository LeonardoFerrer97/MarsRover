using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Exceptions;

namespace MarsRover
{
    public struct Direction
    {
        public static readonly Direction North = new Direction("N", "E", "W");
        public static readonly Direction East = new Direction("E", "S", "N");
        public static readonly Direction South = new Direction("S", "W", "E");
        public static readonly Direction West = new Direction("W", "N", "S");

        private static readonly List<Direction> ValidDirections = new List<Direction>()
        {
            North,East,South,West
        };

        public string Current { get; }
        public string Right { get; }
        public string Left { get; }

        private Direction(string current, string right, string left)
        {
            Current = current;
            Right = right;
            Left = left;
        }

        public static Direction Create(string direction)
        {
            switch (direction)
            {
                case "N":
                    return North;
                case "E":
                    return East;
                case "S":
                    return South;
                case "W":
                    return West;
                default:
                    throw new InvalidDirectionException(direction);
            }
        }

        public Direction TurnLeft()
        {
            var left = Left;
            return ValidDirections.Single(d => d.Current == left);
        }

        public Direction TurnRight()
        {
            var right = Right;
            return ValidDirections.Single(d => d.Current == right);
        }

        public override string ToString() => Current;
    }
}
