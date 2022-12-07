using System.Collections.Generic;
using System.Text.RegularExpressions;
using MarsRover.Exceptions;

namespace MarsRover
{
    public class MovementMessageHandler
    {
        private static readonly string[] LineSeparators = new[] { "///" };

        private static readonly Dictionary<char, Movement> MovementsMapper =
            new Dictionary<char, Movement>()
            {
                {'L', Movement.Left},
                {'R', Movement.Right},
                {'F', Movement.Front},
                {'B', Movement.Back},
            };

        public string HandleMessage(string message)
        {
            var result = WalkRover(message);

            return result;
        }

        private string WalkRover(string message)
        {
            var commands = SplitLines(message);

            var initialPosition = commands.First();
            var marsRover = MarsRover.Create(initialPosition);

            var movements = commands[1];
            if(movements.Contains(" "))
            {
                throw new MessageNotValidException(message);
            }

            List<Movement> movementsMapped = new List<Movement>();

            foreach (var movement in movements)
            {
                if (MovementsMapper.TryGetValue(movement, out var move))
                {
                    movementsMapped.Add(move);
                }
                else
                {
                    throw new InvalidMovementException(movement.ToString());
                }
            }

            var result = marsRover.Move(movementsMapped);

            return result.Position;
        }

        private List<string> SplitLines(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new MessageNotValidException(message);
            }

            var lines = message.Split(
                LineSeparators,
                StringSplitOptions.None
            ).ToList();

            if (lines.Count() < 2)
            {
                throw new MessageNotValidException(message);
            }
               
            return  lines;
        }
    }
}
