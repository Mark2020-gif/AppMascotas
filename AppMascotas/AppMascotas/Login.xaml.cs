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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String sUsario = txtUsuario.Text;
            String sPassword = txtPassword.Text;

            if((sUsario == "Admin") && (sPassword == "1234"))
            {
                Navigation.PushAsync(new Registro());
            }

        }
    }
}