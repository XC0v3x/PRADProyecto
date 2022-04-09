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
    public partial class AddContacto : ContentPage
    {
        //Objetos y variables a Utilizar
        Plugin.Media.Abstractions.MediaFile photo = null;
        public AddContacto()
        {
            InitializeComponent();
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
            if(TxtNombre.Text == null)
            {
                await DisplayAlert("Alerta","El Campo de Nombre Esta Vacio la Informacion Requerida","Ok");
                return;
            }else if(TxtEdad.Text == null)
            {
                await DisplayAlert("Alerta", "El Campo de Edad Esta Vacio Ingrese la Informacion Requerida", "Ok");
                return;
            }else if (TxtTelefono.Text == null)
            {
                await DisplayAlert("Alerta", "El Campo de Telefono Esta Vacio Ingrese la Informacion Requerida", "Ok");
                return;
            }else if(TxtNota.Text == null)
            {
                await DisplayAlert("Alerta", "El Campo Notas esta Vacio Ingrese la Informacion Requerida", "Ok");
                return;
            }
            else
            {
                var Contacto = new ContactoModel()
                {
                    Nombre = TxtNombre.Text,
                    Edad = Convert.ToInt32(TxtEdad.Text),
                    Telefono = Convert.ToDouble(TxtTelefono.Text),
                    Pais = PkPais.SelectedItem.ToString(),
                    Nota = TxtNota.Text,
                    Foto = traeImagenByteArray(),
                };

                if(await ContactosDB.AddContacto(Contacto) > 0)
                    await DisplayAlert("Aviso", "Registro Adicionado", "OK");
                else
                    await DisplayAlert("Aviso", "ha ocurrido un error", "OK");
            }
        }
    }
}