using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PRADProyecto.Views;

namespace PRADProyecto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnAgenda_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactosView());
        }

        private async void BtnSitios_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SitiosView());
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContacto());
        }

        private async void BtnAgregarS_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSitio());
        }

        private async void BtnUnknown_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("You Called for Help", "But Nothing Happened", "???");
        }
    }
}
