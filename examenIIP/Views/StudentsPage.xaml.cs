using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using examenIIP.Models;
using examenIIP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace examenIIP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
        {
            InitializeComponent();
            BindingContext = new StudentsViewModel();
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var student = args.Item as Student;
            if (student == null) return;

            await Navigation.PushAsync(new StudentDetailsPage(student));
            lstStudents.SelectedItem = null;
        }
    }
}