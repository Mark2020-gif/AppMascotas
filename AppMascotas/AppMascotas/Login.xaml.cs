using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppMascotas.Models;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            _googleManager = DependencyService.Get<IGoogleManager>();
            /* CheckUserLoggedIn();*/
        }
       
        public static IEnumerable<Usuarios> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Usuarios>("SELECT * FROM Usuarios where Usuario = ? and Contrasenia =?", usuario, contrasenia);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "db_mascotas.db3");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<Usuarios>();
                IEnumerable<Usuarios> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new Registro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario no existe", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Usuario no existe", "OK");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevoRegistro());

        }

        /* private void CheckUserLoggedIn()
 {
     _googleManager.Login(OnLoginComplete);
 }*/

        private void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;
                txtUsuario.Text = GoogleUser.Email;
                IsLogedIn = true;
            }
            else
            {
                DisplayAlert("Message", message, "Ok");
            }
        }

        private void GoogleLogout()
        {
            _googleManager.Logout();
            IsLogedIn = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            _googleManager.Login(OnLoginComplete);
            _googleManager.Logout();


            txtUsuario.Text = "";
            

        }
    }
}