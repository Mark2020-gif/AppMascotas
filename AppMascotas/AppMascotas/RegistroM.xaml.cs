using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using AppMascotas.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace AppMascotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroM : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Animales> tablaUsuarios;

        public RegistroM()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            consulta();

        }

        private async void consulta()
        {
            var registro = await con.Table<Animales>().ToListAsync();
            tablaUsuarios = new ObservableCollection<Animales>(registro);
            ListaMascotas.ItemsSource = tablaUsuarios;
        }

        protected async override void OnAppearing()
        {
            var DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "db_mascotas.db3");
            var db = new SQLiteConnection(DataBasePath);

            db.CreateTable<Animales>();
            var ResulRegistros = await con.Table<Animales>().ToListAsync();
            tablaUsuarios = new ObservableCollection<Animales>(ResulRegistros);
            ListaMascotas.ItemsSource = tablaUsuarios;
            base.OnAppearing();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Animales)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(ID, Obj.IdMascota.ToString(), Obj.NombreM.ToString(), Obj.Raza.ToString(), Obj.Sexo.ToString(), Obj.NombreD.ToString(), Obj.Direccion.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}