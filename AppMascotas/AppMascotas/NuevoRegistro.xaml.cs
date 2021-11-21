using AppMascotas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public NuevoRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new Usuarios { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasenia = txtContrasenia.Text };
                con.InsertAsync(Registros);
                DisplayAlert("Alerta", "Dato ingresado", "OK");

                txtNombre.Text = "";
                txtContrasenia.Text = "";
                txtUsuario.Text = "";

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");

            }

        }

        private  async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());

        }
    }
}