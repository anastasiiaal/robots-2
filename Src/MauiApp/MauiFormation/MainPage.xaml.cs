using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiFormation
{
    public partial class MainPage : ContentPage
    {
        int count = 0;


        private double rotation = 100;

        public double Rotation
        {
            get { return rotation; }
            set {
                rotation = value;
                OnPropertyChanged();
            }
        }


        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void BtnTest_Clicked(object sender, EventArgs e)
        {
            Rotation = 45;
        }
    }
}