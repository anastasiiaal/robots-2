using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public abstract class RobotAbstrait
    {
        public decimal Vitesse { get; set; }
        public string Nom { get; set; }

        public abstract string Démarrer();
        public string Arrêter()
        {
            return "Arrêt du robot";
        }
    }
}
