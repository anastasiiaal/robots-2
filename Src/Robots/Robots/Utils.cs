using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public static class Utils
    {
        public static int CalculerDistance(Point PointDépart, Point PointArrivé)
        {
            return Math.Abs(PointArrivé.X - PointDépart.X) + Math.Abs(PointArrivé.Y - PointDépart.Y);
        }
    }
}
