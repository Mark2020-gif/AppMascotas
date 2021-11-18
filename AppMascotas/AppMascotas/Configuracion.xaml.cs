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
    public partial class Configuracion : ContentPage
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Exit", "Quieres cerrar sesion", "Yes", "No");
            if (answer)
            {
               
                await Navigation.PushAsync(new Login());
            }
            else
            {
                App.Current.MainPage = new Login();
            }


        }
    }
}