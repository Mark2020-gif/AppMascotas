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
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;

        private SQLiteAsyncConnection con; 
        IEnumerable<Animales> ResultadoDelete; 
        IEnumerable<Animales> ResultadoUpdate;
        public Elemento(int Id, string IdMascota, string NombreM, string Raza, string Sexo, string NombreD, string Direccion)
        {
            con = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = Id;
            InitializeComponent();
             lbId.Text = IdMascota;
            lbNombre.Text = NombreM;
            lbMascota.Text = Raza;
            lbSexo.Text = Sexo;
            lbDuenio.Text = NombreD;
            lbDir.Text = Direccion;

        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "db_mascotas.db3");
                var db = new SQLiteConnection(DataBasePath);
                ResultadoUpdate = Update(db, lbId.Text, lbNombre.Text, lbMascota.Text, lbSexo.Text, lbDuenio.Text, lbDir.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "OK");

                lbId.Text = "";
                lbNombre.Text = "";
                lbMascota.Text = "";
                lbSexo.Text = "";
                lbDuenio.Text = "";
                lbDir.Text = "";

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "OK");
            }

        }
        public static IEnumerable<Animales> Update(SQLiteConnection db, string idMascota, string nombreM, string raza, string sexo, string nombreD, string direccion, int id)
        {
            return db.Query<Animales>("UPDATE animales SET IdMascota=?, NombreM=?, Raza=?, Sexo=?, NombreD=?, Direccion=? where Id=?", idMascota, nombreM, raza, sexo, nombreD, direccion, id);

        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "db_mascotas.db3");
                var db = new SQLiteConnection(DataBasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }

        }
        public static IEnumerable<Animales> Delete(SQLiteConnection db, int idSeleccionado)
        {
            return db.Query<Animales>("DELETE FROM animales where Id = ?", idSeleccionado);

        }

    }
}