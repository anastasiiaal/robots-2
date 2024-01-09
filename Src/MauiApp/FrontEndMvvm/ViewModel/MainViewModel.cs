using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FrontEndMvvm.Domain;
using FrontEndMvvm.Domain.Enum;
using Microsoft.Maui.Controls;

namespace FrontEndMvvm.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public string RobotName { get; set; }
        public EnumTypeRobot RobotType { get; set; }

        public ICommand AddRobotCommand { get; private set; }
        public List<EnumTypeRobot> RobotTypes { get { return typeof(EnumTypeRobot).GetEnumValues().Cast<EnumTypeRobot>().ToList(); } }

        public ObservableCollection<Robot> Robots { get; set; } = new ObservableCollection<Robot>() { new Robot(){
            Name = "R2D2",
            Type = EnumTypeRobot.DroideAstromecano,
            Size = 0.96
        } };

    

        public MainViewModel()
        {
            AddRobotCommand = new Command(AddRobot);
        }

        private void AddRobot(object obj)
        {
           Robots.Add(new Robot { Name = RobotName, Type = RobotType, Size = 0.96 });
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
