using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite_Example
{
    public partial class MainPage : ContentPage
    {
        private SQLiteConnection conn;
        public Employer employer;

        public MainPage()
        {
            InitializeComponent();
            // Get connection string from interface and android specific class
            conn = DependencyService.Get<ISQLiteInterface>().GetConnectionWithDB();
            //Create table of Eployer Class
            conn.CreateTable<Employer>();
        }

        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            employer = new Employer();
            employer.Name = Name.Text;
            employer.City = City.Text;
            // Insert records in table
            conn.Insert(employer);

            Name.Text = "";
            City.Text = "";
            DisplayAlert("Message", "Record Saved", "Ok");
            
        }
        private void ReadButton_Clicked(object sender, EventArgs e)
        {
            var empData = (from emp in conn.Table<Employer>() select emp);
            listEmployer.ItemsSource = null;
            listEmployer.ItemsSource = empData;
        }
        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            employer = new Employer();
            // Get Primary Key and Data
            employer = conn.Table<Employer>().Where(i => i.Name == Name.Text).FirstOrDefault();
            // Update Record
            employer.City = City.Text;
            int result = conn.Update(employer);

            Name.Text = "";
            City.Text = "";
            DisplayAlert("Message", "Record Updated", "Ok");
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            employer = new Employer();
            // Get Primary Key and Data
            employer = conn.Table<Employer>().Where(i => i.Name == Name.Text).FirstOrDefault();
            // Delete Record
            int result = conn.Delete(employer);

            Name.Text = "";
            City.Text = "";
            DisplayAlert("Message", "Record Deleted", "Ok");
        }
       
    }
}
