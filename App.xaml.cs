using System;
using ToDoXamarin.DataBase;
using ToDoXamarin.Models;
using ToDoXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new Principal();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
