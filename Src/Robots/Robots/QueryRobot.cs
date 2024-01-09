using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class QueryRobot
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

/*        public QueryRobot(string name, int year, int x, int y)
        {
            Name = name;
            Year = year;
            X = x;
            Y = y;
        }*/

        public QueryRobot()
        {

        }

        // function to show query robots in console
        public override string ToString()
        {
            return $"Robot {Name} - {Year} - {X}:{Y}";
        }

        public double DistanceToOrigin()
        {
            double distance = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            return distance;
        }
    }
}
