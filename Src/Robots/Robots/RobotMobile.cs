using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class RobotMobile : Robot, IRobotNettoyage
    {
        public int Vitesse { get; set; }
        public RobotMobile(string name, Point position, int vitesse) : base(name,position)
        {
            Vitesse = vitesse;
            
        }

        public int CalculerDuréeDeDéplacement(int posX, int posY)
        {
            return Utils.CalculerDistance(Position,new Point { X = posX,Y=posY} ) / Vitesse;
        }

        public override string AfficherPosition()
        {
            return $"Je suis un robot mobile à la position {Position.X}, {Position.Y}";
        }

        public void Nettoyer()
        {
            Console.WriteLine($"{Nom} nettoie");
        }

        public void Déplacer(Point PointDestination)
        {

            Console.WriteLine($"les robot {Nom}, c'est déplacer de {Utils.CalculerDistance(Position, PointDestination)}");

                Position = PointDestination;
         
        }
    }
}
