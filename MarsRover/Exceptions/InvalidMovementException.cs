using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exceptions
{
    [Serializable]
    public class InvalidMovementException : Exception
    {
        public InvalidMovementException() { }

        public InvalidMovementException(string moviment)
            : base(String.Format("Invalid moviment {0}", moviment))
        {

        }
    }
}
