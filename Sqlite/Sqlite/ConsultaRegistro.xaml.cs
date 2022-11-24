using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiantes> tablaEstudiantes;

        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos();
        }
        
        public async void Datos()
        {
            var Resultado = await con.Table<Estudiantes>().ToListAsync();
            tablaEstudiantes = new ObservableCollection<Estudiantes>(Resultado);
            ListaEstudiantes.ItemsSource = tablaEstudiantes;
        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiantes)e.SelectedItem;
            var item = Obj.Id.ToString();
            var IdSelecionado = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new Elemento(IdSelecionado));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}