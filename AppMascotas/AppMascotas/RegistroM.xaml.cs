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

namespace AppMascotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroM : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Usuarios> tablaAnimales;

        public RegistroM()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            consulta();

        }

        private async void consulta()
        {
            var registro = await con.Table<Usuarios>().ToListAsync();
            tablaAnimales = new ObservableCollection<Usuarios>(registro);
            ListaMascotas.ItemsSource = tablaAnimales;
        }

        private void ListaMascotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


        }
    }
}