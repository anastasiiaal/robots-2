using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.CustomExceptions
{
    public class StatusRobotException : Exception
    {
        public StatusRobotException(string message) : base(message)
        {
                
        }
    }
}
