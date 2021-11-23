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
    public partial class Registro : TabbedPage
    {
        public string correo;

        public Registro(string Email)
        {
            InitializeComponent();

            //Correo(Email);
            DisplayAlert("Usuario conectado", Email, "OK");
            //Navigation.PushAsync(new Configuracion(Email));
        }

        /*public string Correo(string Email)
        {
            correo = Email;
            return correo;
        }*/
    }
}