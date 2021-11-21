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
        private ObservableCollection<Animales> TablaAnimales;
       

        public RegistroM()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            consulta();
        }

        protected async  void consulta()
        {
            var registros = await con.Table<Animales>().ToListAsync();
            TablaAnimales = new ObservableCollection<Animales>(registros);
            Carnet.ItemsSource = TablaAnimales;
        }

      
        private void Carnet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Animales)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
              //  Navigation.PushAsync(new Home(ID));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}