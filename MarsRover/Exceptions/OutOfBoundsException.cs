using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Exceptions
{
    [Serializable]
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException() { }

        public OutOfBoundsException(string x, string y)
            : base(String.Format("Rover is outside of rovers (x:{0}, y:{1}", x,y))
        {

        }
    }
}
