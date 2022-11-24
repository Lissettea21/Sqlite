using System;
using System.Collections.Generic;
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
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiantes> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiantes>("SELECT * FROM Estudiantes where Usuario=? and contrasena=?", usuario, contrasena);

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiantes>();
                IEnumerable<Estudiantes> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasena.Text);

                if (resultado.Count() > 0) 
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "No existe el usuario", "cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "cerrar");

            }
        }
    }
}