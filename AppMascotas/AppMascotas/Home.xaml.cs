using AppMascotas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Home()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }
        

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Animales{ IdMascota = txtIdMascota.Text, NombreM = txtNombreM.Text, Raza = txtRaza.Text, Sexo = txtSexo.Text , NombreD= txtNombreD.Text, Direccion= txtDireccion.Text };
                con.InsertAsync(DatosRegistro);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "ok");
            }
          
            LimpiarFormulario();
        }
        void LimpiarFormulario() {
            txtNombreM.Text = "";
            txtRaza.Text = "";
            txtSexo.Text = "";
            txtNombreD.Text = "";
            txtDireccion.Text = "";
            DisplayAlert("Mensaje", "Se Registro correctamente", "Ok");
        
        }
    }
}