using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FrontEnd.Domain;
using FrontEnd.Infrastructure;
using Speech;

namespace FrontEnd.ViewModels
{
    public class RobotViewModel : INotifyPropertyChanged
    {
        Communication communication = new Communication();
        private string robotName;
        public string RobotName
        {
            get { return robotName; }
            set { robotName = value; OnPropertyChanged(); }
        }

        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; OnPropertyChanged(); }
        }

        private string robotType;

        public string RobotType
        {
            get { return robotType; }
            set { robotType = value; OnPropertyChanged(); }
        }


        public List<string> RobotTypes { get; set; } = new List<string>()
        {
            "Droïde de protocole",
            "Droïde astromécano",
        };
        public ObservableCollection<Robot> Robots { get; set; } = new ObservableCollection<Robot>() { new Robot(){
            Name = "R2D2",
            TypeRobot = "Droïde astromécano",
            Size = 30
        } };

        public RobotViewModel()
        {
            AddRobotCommand = new Command(AddRobot);
        }

        public ICommand AddRobotCommand { get; private set; }
        public void AddRobot(object obj)
        {
           Robots.Add(new Robot { Name = RobotName, TypeRobot = RobotType, Size = Size });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
