using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppMascotas.Models;
using Newtonsoft.Json;
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

        public string RequestUri { get; private set; }

        private async void Button_Clicked(object sender, EventArgs e)
        {
             String sUsario = txtUsuario.Text;
            String sPassword = txtPassword.Text;

            if((sUsario == "Admin") && (sPassword == "1234"))
            {
                Navigation.PushAsync(new Registro());
           
            }

            /*sesion log = new sesion
            {
               usuario = txtUsuario.Text,
                pass = txtPassword.Text

            };
            //Uri RequestUri = new Uri("http://127.0.0.1/moviles/login.php");

             
           // var request = new HttpRequestMessage();
           // request.RequestUri = new Uri("http://127.0.0.1/moviles/login.php");
            //var json = JsonConvert.SerializeObject(log);
           // request.Method = HttpMethod.Get;
            // var contentJaon = new StringContent(json, Encoding.UTF8, "application/json");
           // request.Headers.Add("Accept", "application/json");
           // var client = new HttpClient();
           // HttpResponseMessage response = await client.SendAsync(request);
            //var response = await client.PostAsync(RequestUri, contentJaon);
           // if (response.StatusCode == System.Net.HttpStatusCode.OK)
           // {
            //    await Navigation.PushAsync(new Registro());
            //}*/
        }
    }
}