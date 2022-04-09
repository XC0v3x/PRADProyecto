﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRADProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMapa : ContentPage
    {
        public PageMapa()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                var pin = new Pin()
                {
                    Position = new Position(location.Latitude, location.Longitude),
                    Label = "Ute Eta Aqui"
                };
                Mapa.Pins.Add(pin);

                Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(100.00)));
            }
;
        }
    }
}