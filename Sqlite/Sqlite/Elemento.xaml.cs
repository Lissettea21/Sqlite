using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqlite.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int Idsel;
        private SQLiteAsyncConnection con;

        IEnumerable<Estudiantes> borrar;
        IEnumerable<Estudiantes> actualizar;

        public Elemento(int ID)
        {
            InitializeComponent();
            Idsel = ID;
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiantes> borrar1(SQLiteConnection db, int id)
        {
            return db.Query<Estudiantes>("Delete from Estudiantes where id=?", id);
        }
        
        public static IEnumerable<Estudiantes> actualizar1(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiantes>("update Estudiantes set Nombre = ?, Usuario= ?, Contrasena=? where id = ?", nombre, usuario, contrasena, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                actualizar = actualizar1(db, Idsel, txtNombre.Text, txtUsuario.Text, txtContraseña.Text);
                DisplayAlert("Mensaje", "Actualizar", "Ok");
                
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                borrar = borrar1(db, Idsel);
                DisplayAlert("Mensaje", "Eliminar", "Ok");

                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}