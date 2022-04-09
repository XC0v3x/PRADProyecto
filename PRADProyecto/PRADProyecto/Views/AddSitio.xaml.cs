using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Essentials;
using PRADProyecto.Models;
using PRADProyecto.Controllers;
using Plugin.Media;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRADProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSitio : ContentPage
    {
        //Objetos y variables a Utilizar
        Plugin.Media.Abstractions.MediaFile photo = null;

        public AddSitio()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            CancellationTokenSource cts;

            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    TxtLatitud.Text = Convert.ToString(location.Latitude);
                    TxtLongitud.Text = Convert.ToString(location.Longitude);
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    location = await Geolocation.GetLocationAsync(request, cts.Token);

                    if (location != null)
                    {
                        TxtLatitud.Text = Convert.ToString(location.Latitude);
                        TxtLongitud.Text = Convert.ToString(location.Longitude);
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                fnsEx.ToString();
                // Handle not supported on device exception
            }
        }


        private Byte[] traeImagenByteArray()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;
        }

        private async void BtnFoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "FotosApp",
                Name = "test.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            if(TxtDesc.Text == null)
            {
                await DisplayAlert("Alerta","El Campo Descripcion esta vacio Porfavor Llenarlo","Ok");
                return;
            }else if (TxtLatitud.Text == null)
            {
                await DisplayAlert("Alerta","El Campo Latitud No tiene un Valor Ingrese el Valor","Ok");
                return;
            }else if (TxtLongitud.Text == null)
            {
                await DisplayAlert("Alerta","El Campo Longitud No tiene un Valor Ingrese el Valor","Ok");
                return;
            }else if (TxtNota.Text == null)
            {
                await DisplayAlert("Alerta","El Campo Nota Esta Vacio Porfavor Llenarlo","Ok");
                return;
            }
            else
            {
                var site = new SitesModel()
                {
                    Descripcion = TxtDesc.Text,
                    Longitud = Convert.ToDouble(TxtLongitud.Text),
                    Latitud = Convert.ToDouble(TxtLatitud.Text),
                    Pais = PkPais.SelectedItem.ToString(),
                    Foto = traeImagenByteArray(),
                    Nota = TxtNota.Text
                };

                if (await SitiosDB.AddSitio(site) > 0)
                    await DisplayAlert("Aviso", "Registro Adicionado", "OK");
                else
                    await DisplayAlert("Aviso", "ha ocurrido un error", "OK");
            }
        }
    }
}