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
    public partial class ContactosView : ContentPage
    {
        //variables a Utilizar
        string Number = "88224658";
        int id;
        string name;
        int edad;
        double telefono;
        string pais;
        string nota;

        

        public ContactosView()
        {
            InitializeComponent();
        }



        private void ListaContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Models.ContactoModel Contacto = (Models.ContactoModel)e.CurrentSelection.FirstOrDefault();
                Number = Contacto.Telefono.ToString();
                id = Contacto.ID;
                name = Contacto.Nombre;
                edad = Contacto.Edad;
                telefono = Contacto.Telefono;
                pais = Contacto.Pais;  
                nota = Contacto.Nota;
            }

            
        }

        private async void TbAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContacto());
        }

        private void TbLlamar_Clicked(object sender, EventArgs e)
        {
            PlacePhoneCall(Number);
        }

        private async  void TbBorrar_Clicked(object sender, EventArgs e)
        {
            var Contacto = new ContactoModel()
            {
                ID = id,
                Nombre = name,
                Edad = edad,
                Telefono = telefono,
                Pais = pais,
                Nota = nota
                
            };

            if (await ContactosDB.DelContacto(Contacto) > 0)
                await DisplayAlert("Aviso", "Registro Eliminado", "OK");
            else
                await DisplayAlert("Aviso", "ha ocurrido un error", "OK");
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        
        
            public void PlacePhoneCall(string number)
            {
                try
                {
                    PhoneDialer.Open(number);
                }
                catch (ArgumentNullException anEx)
                {
                // Number was null or white space
                DisplayAlert("Advertencia",Convert.ToString(anEx),"Ok");
                }
                catch (FeatureNotSupportedException ex)
                {
                // Phone Dialer is not supported on this device.
                DisplayAlert("Advertencia", Convert.ToString(ex), "Ok");
                }
                catch (Exception ex)
                {
                // Other error has occurred.
                DisplayAlert("Advertencia", Convert.ToString(ex), "Ok");
                }
            }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaContactos.ItemsSource = await ContactosDB.ObtenerListaContactos();
        }

        private async void TbVerImagen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageImagen());
        }
    }
}