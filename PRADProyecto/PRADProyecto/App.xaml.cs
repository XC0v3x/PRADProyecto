using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PRADProyecto.Controllers;
using System.IO;
using PRADProyecto.Views;

namespace PRADProyecto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DB.conexion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DBPRAD.db3"));

            MainPage = new NavigationPage(new MainPage());
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
