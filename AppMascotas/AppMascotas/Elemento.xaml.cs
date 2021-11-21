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
        IEnumerable<Usuarios> ResultadoDelete; 
        IEnumerable<Usuarios> ResultadoUpdate;
        public Elemento(int id, string IdMascota, string NombreM, string Raza, string Sexo, string NombreD, string Direccion)
        {
            con = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = id;
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
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "OK");
            }

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
        public static IEnumerable<Usuarios> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Usuarios>("DELETE FROM usuarios where Id = ?", id);

        }


        public static IEnumerable<Usuarios> Update(SQLiteConnection db, string IdMascota, string NombreM, string Raza, string Sexo, string NombreD, string Direccion, int id)
        {
            return db.Query<Usuarios>("UPDATE usuarios SET Nombre=?, Usuario=? ," + "Contrasenia=? where Id=?", IdMascota, NombreM, Raza, Sexo, NombreD, Direccion, id);

        }
    }
}