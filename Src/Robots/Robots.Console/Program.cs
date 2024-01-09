 // See https://aka.ms/new-console-template for more information
using Robots;
using Robots.CustomExceptions;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Dynamic;

Console.WriteLine("Hello, World!");

List<int> list = new List<int>();


List<NewRobot> robots = new List<NewRobot>()
{ 
new NewRobot { Id = 5, Name = "R2D5", Status = "En marche" },
};

robots.Add(new NewRobot { Id = 1, Name = "R2D2", Status = "En marche" });
robots.Add(new NewRobot { Id = 2, Name = "R2D3", Status = "En marche" });
robots.Add(new NewRobot { Id = 3, Name = "R2D4", Status = "En marche" });
robots.Add(new NewRobot { Id = 4, Name = "R2D5", Status = "En marche" });

Dictionary<int, NewRobot> DictionnaryRobot = new Dictionary<int, NewRobot>();
DictionnaryRobot.Add(1, new NewRobot { Id = 1, Name = "R2D2", Status = "En marche" });

var DictionnaryRobot2 = new Dictionary<int, NewRobot>
{
    { 1, new NewRobot { Id = 1, Name = "R2D2", Status = "En marche" } },
    { 2, new NewRobot { Id = 2, Name = "R2D3", Status = "En marche" } },
    { 3, new NewRobot { Id = 3, Name = "R2D4", Status = "En marche" } },
    { 4, new NewRobot { Id = 4, Name = "R2D5", Status = "En marche" } }
};

var DictionnaryRobot3 = robots.ToDictionary(r => r.Id, r => r);

var QueueRobot = new Queue<NewRobot>();
QueueRobot.Enqueue(new NewRobot { Id = 3, Name = "R2D4", Status = "Arret" });
QueueRobot.Enqueue(new NewRobot { Id = 1, Name = "R2D2", Status = "En marche" });
QueueRobot.Enqueue(new NewRobot { Id = 2, Name = "R2D3", Status = "En marche" });

// "last in first out"
var StackRobot = new Stack<NewRobot>();
StackRobot.Push(new NewRobot { Id = 1, Name = "R2D2", Status = "En marche" });
StackRobot.Push(new NewRobot { Id = 2, Name = "R2D3", Status = "Arret" });
StackRobot.Push(new NewRobot { Id = 3, Name = "R2D4", Status = "En marche" });

// on peut ajouter dans des differentes endroits
var LinkedListRobot = new LinkedList<NewRobot>();
LinkedListRobot.AddFirst(new NewRobot { Id = 1, Name = "R2D2", Status = "En marche" });
LinkedListRobot.AddLast(new NewRobot { Id = 2, Name = "R2D3", Status = "Arret" });
LinkedListRobot.AddLast(new NewRobot { Id = 3, Name = "R2D4", Status = "En marche" });

var observableCollectionRobot = new System.Collections.ObjectModel.ObservableCollection<NewRobot>();
observableCollectionRobot.Add(new NewRobot { Id = 1, Name = "R2D2", Status = "En marche" });
observableCollectionRobot.Add(new NewRobot { Id = 2, Name = "R2D3", Status = "Arret" });

// on choisit par quoi in veut trier
var sortedListRobot = new SortedList<int, NewRobot>();
sortedListRobot.Add(2, new NewRobot { Id = 2, Name = "R2D3", Status = "En marche" });
sortedListRobot.Add(1, new NewRobot { Id = 1, Name = "R2D2", Status = "Arret" });

// pour parcourir => les foreach
Console.WriteLine("List");
foreach (var robot in robots)
{
    Console.WriteLine(robot.ToString());
}
Console.WriteLine("Dictionnary");
foreach (var robot in DictionnaryRobot)
{
    Console.WriteLine(robot.Value.ToString());
}
Console.WriteLine("Dictionnary2");
foreach (var robot in DictionnaryRobot2)
{
    Console.WriteLine(robot.Value.ToString());
}
Console.WriteLine("Dictionnary3");
foreach (var robot in DictionnaryRobot3)
{
    Console.WriteLine(robot.Value.ToString());
}   
Console.WriteLine("Queue");
foreach (var robot in QueueRobot)
{
    Console.WriteLine(robot.ToString());
}
Console.WriteLine("Stack");
foreach (var robot in StackRobot)
{
    Console.WriteLine(robot.ToString());
}
Console.WriteLine("LinkedList");
foreach (var robot in LinkedListRobot)
{
    Console.WriteLine(robot.ToString());
}
Console.WriteLine("ObservableCollection");
foreach (var robot in observableCollectionRobot)
{
    Console.WriteLine(robot.ToString());
}
Console.WriteLine("SortedList");
foreach (var robot in sortedListRobot)
{
    Console.WriteLine(robot.Value.ToString());
}

//supprimer un element de chaque type de liste
robots.RemoveAt(0);
robots.Remove(robots[1]);
DictionnaryRobot.Remove(1);
DictionnaryRobot2.Remove(1);
DictionnaryRobot3.Remove(1);
QueueRobot.Dequeue();
StackRobot.Pop();
LinkedListRobot.RemoveFirst(); // on peut aussi faire RemoveLast();
observableCollectionRobot.RemoveAt(0);
sortedListRobot.Remove(1);

// all robots put to stop to test isArret 
/*foreach (var robot in robots)
{
    robot.Status = "Arret";
}*/

// one robot put to stop to test isArret2 
robots[1].Status = "Arret";

// Vérification si les changements ont été appliqués
Console.WriteLine("List after changes");
foreach (var robot in robots)
{
    Console.WriteLine(robot.ToString());
}

bool isArret = robots.All(x=> x.Status == "Arret");
bool isArret2 = robots.Any(x => x.Status == "Arret");

// afficher que les robots "En marche", sinon dire que tous sont à l'arret
if (!isArret)
{
    foreach (var robot in robots)
    {
        if (robot.Status == "En marche")
        {
            Console.WriteLine(robot);
        }
    }
} 
else
{
    Console.WriteLine("Tous les robots sont à l'arret");
}


try
{
    if (isArret2)
    {
        Console.WriteLine("Tous les robots sont à l'arret");
        throw new StatusRobotException("Tous les robots ne sont pas à l'arret");

    }
}
catch (StatusRobotException e)
{
    Console.Write("exception Custom :");
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.Write("exception :");
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("Fin du programme");
}

// LINQ => queries to filter robots
var result = from r in robots
             where r.Status == "Arret"
             select r;
Console.WriteLine(result);

var result2 = robots.Where(robot => robot.Status == "Arret").ToList();
foreach (var robot in result2)
{
    Console.WriteLine(robot);
}

// ______________________
// tests LINQ
List<QueryRobot> queryRobots = new List<QueryRobot>()
{
    new QueryRobot { Name = "R2D1", Year = 2005, X = 1, Y = 1 },
};

queryRobots.Add(new QueryRobot { Name = "R2D2", Year = 2010, X = 2, Y = 2 });
queryRobots.Add(new QueryRobot { Name = "R2D3", Year = 2011, X = 3, Y = 3 });
queryRobots.Add(new QueryRobot { Name = "R2D4", Year = 2004, X = 4, Y = 4 });
queryRobots.Add(new QueryRobot { Name = "R2D5", Year = 2023, X = 5, Y = 5 });

Console.WriteLine("Query Robots");
foreach (var queryRobot in queryRobots)
{
    Console.WriteLine(queryRobot.ToString());
}

// robots from 2005
Console.WriteLine("Query Robots 2005++");
var queryRobotsResult1 = from r in queryRobots
                         where r.Year > 2005
                         select r;
foreach (var robot in queryRobotsResult1)
{
    Console.WriteLine(robot);
}

var queryRobotsSortedByYear = from r in queryRobots
                              orderby r.Year
                              select r;
// ===
var ListRobotYearSup2005 = queryRobots.Where(r => r.Year > 2005).ToList();
foreach (var robot in ListRobotYearSup2005)
{
    Console.WriteLine(robot);
}

// oldest to newest
Console.WriteLine("Query Robots triés par année de construction (plus ancienne à plus récente):");
foreach (var robot in queryRobotsSortedByYear)
{
    Console.WriteLine(robot.ToString());
}

// oldest robot
Console.WriteLine("Le plus ancien de Query Robots");
var oldestRobot = queryRobots.OrderBy(r => r.Year).FirstOrDefault();
if (oldestRobot != null)
{
    Console.WriteLine($"Le robot le plus ancien est : {oldestRobot.ToString()}");
}
else
{
    Console.WriteLine("Aucun robot trouvé dans la liste.");
}

// distance to start 0:0
var distances = queryRobots.Select(robot => new
{
    Robot = robot,
    Distance = Math.Sqrt(Math.Pow(robot.X, 2) + Math.Pow(robot.Y, 2))
});

Console.WriteLine("Distances entre les robots et le point (0, 0):");
foreach (var item in distances)
{
    Console.WriteLine($"{item.Robot.Name} - Distance : {item.Distance:F2}");
}

// le robot le plus proche de start
var closestRobot = queryRobots.OrderBy(robot => robot.DistanceToOrigin()).FirstOrDefault();

if (closestRobot != null)
{
    Console.WriteLine($"Le robot le plus proche est : {closestRobot.ToString()}");
}
else
{
    Console.WriteLine("Aucun robot trouvé dans la liste.");
}

//const int MAX_ROBOTS = 5;

//Robot[] robots = new Robot[MAX_ROBOTS];

//for (int i = 0; i < 3; i++)
//{
//    robots[i] = new Robot($"R2D{i}", (decimal)i);
//}

//decimal vitesseMoyenne = 0;
//for (int i = 0; i < 2; i++)
//{
//    vitesseMoyenne +=  robots[i].Vitesse;
//}

//vitesseMoyenne = vitesseMoyenne / 3;

//var VitesseMoyenne = robots.Average(r=> r.Vitesse);

//Console.WriteLine($"La vitesse moyenne est de {vitesseMoyenne}");

//var robot = robots[0];
//double test = (double)robot.Vitesse;

//int[,] tableau = new int[2, 3];
//tableau[0, 0] = 1;
//tableau[0, 1] = 2;


//Robot robot = new Robot("R2D2", new Point(0, 0));

//Console.WriteLine(robot.AfficherPosition());
//RobotMobile robotMobile = new RobotMobile("R2D2", new Point(0, 0), 10);
//robotMobile.Avancer(10, 10);
//Console.WriteLine($"ma vitesse est de {robotMobile.CalculerDuréeDeDéplacement(20, 20)}");
//Console.WriteLine(robotMobile.AfficherPosition());
//Console.WriteLine(robotMobile.Arrêter());
//Console.WriteLine(robot.Démarrer());
//robotMobile.Nettoyer();
//robotMobile.Déplacer(new Point { X = 30, Y = 30 });


//Robot AfficherNomRobot(Robot robot, string nouveauNom)
//{
//    robot.Name = nouveauNom;
//    return robot;    
//}

