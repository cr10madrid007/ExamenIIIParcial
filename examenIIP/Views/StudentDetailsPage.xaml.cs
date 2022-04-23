using examenIIP.Models;
using examenIIP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace examenIIP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetailsPage : ContentPage
    {
        DBFirebase services;
        public StudentDetailsPage(Student student)
        {
            InitializeComponent();
            BindingContext = student;
            services =  new DBFirebase();

        }

        public async void BtnUpdate_Student(object sender, EventArgs e)
        {
            await services.UpdateStudent( int.Parse( Id.Text), Description.Text,int.Parse( Monto.Text), Fecha.Date , "");
            await Navigation.PushAsync(new StudentsPage());
        }

        public async void BtnDelete_Student(object sender, EventArgs e)
        {
            await services.DeleteStudent(int.Parse(Id.Text), Description.Text, int.Parse(Monto.Text), Fecha.Date, "");
            await Navigation.PushAsync(new StudentsPage());
        }
    }
}