using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRADProyecto.Views;
using Xamarin.Essentials;
using PRADProyecto.Models;
using PRADProyecto.Controllers;
using Plugin.Media;
using System.IO;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PRADProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SitiosView : ContentPage
    {
        //variables a utilizar
        public int id;
        public double lat;
        public double lon;
        public string pais;
        public byte[] foto;

        public SitiosView()
        {
            InitializeComponent();
        }

        

        private void ListaSitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection != null)
            {
                Models.SitesModel Site = (Models.SitesModel)e.CurrentSelection.FirstOrDefault();
                id = Site.ID;
                lat = Site.Latitud;
                lon = Site.Longitud;
                pais = Site.Pais;
                foto = Site.Foto;
            }
        }

        private async void TbAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSitio());
        }

        private void TbLlamar_Clicked(object sender, EventArgs e)
        {

        }

        private async void TbBorrar_Clicked(object sender, EventArgs e)
        {
            var Site = new SitesModel()
            {
                ID = id,

            };

            if (await SitiosDB.DelSitio(Site) > 0)
                await DisplayAlert("Aviso", "Registro Eliminado", "OK");
            else
                await DisplayAlert("Aviso", "ha ocurrido un error", "OK");
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private async void TbMapa_Clicked(object sender, EventArgs e)
        {
            var Site = new SitesModel()
            {
                ID = id,
                Longitud = lon,
                Latitud = lat,
                Pais = pais

            };

            var mappage = new Views.PageMapa();
            mappage.BindingContext = Site;
            await Navigation.PushAsync(mappage);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaSitios.ItemsSource = await SitiosDB.ObtenerListaSitios();
        }
    }
}