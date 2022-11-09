using food_ordering_app.Model;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(food_ordering_app.iOS.SQLiteIOS))]
namespace food_ordering_app.iOS
{
    public class SQLiteIOS: ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}