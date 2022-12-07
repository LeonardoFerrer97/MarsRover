using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exceptions
{
    [Serializable]
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException() { }

        public InvalidPositionException(string position)
            : base(String.Format("Invalid position {0}, it has to be a number.", position))
        {

        }
    }
}
