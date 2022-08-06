using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLite_Example.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace SQLite_Example.Droid
{
    public class SQLite_Android : ISQLiteInterface
    {
        SQLiteConnection ISQLiteInterface.GetConnectionWithDB()
        {
            string dbName = "SampleDatabase.sqlite";
            string dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string databasePath = Path.Combine(dbPath, dbName);
            SQLiteConnection con = new SQLiteConnection(databasePath); // Create Connection
            return con;
        }
    }
}