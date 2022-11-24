using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Path = System.IO.Path;
using Sqlite.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(SqlCliente))]
namespace Sqlite.Droid
{
    public class SqlCliente : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var DocuemnthPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(DocuemnthPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}