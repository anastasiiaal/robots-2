using FrontEndMvvm.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndMvvm.Domain
{
    public class Robot
    {
        public string Name { get; set; }
        public EnumTypeRobot Type { get; set; }
        public double Size { get; set; }
    }
}
