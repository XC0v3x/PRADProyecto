using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRADProyecto.Views;
using PRADProyecto.Models;
using PRADProyecto.Controllers;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRADProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageImagen : ContentPage
    {
        
       
        public PageImagen()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaContactos.ItemsSource = await ContactosDB.ObtenerListaContactos();
        }

        private void ListaContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}