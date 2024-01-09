using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class NewRobot
    {
        public NewRobot()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }

        public override string ToString()
        {
            return $"Robot {Id} : {Name} - {Status} - {CreationDate}";
        }
    }
}
