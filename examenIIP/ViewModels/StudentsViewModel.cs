using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using examenIIP.Models;
using MvvmHelpers;
using Xamarin.Forms;
using examenIIP.Services;
namespace examenIIP.ViewModels
{
    public class StudentsViewModel: BaseViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Recibo { get; set; }

        private DBFirebase services;
        public Command AddStudentCommand { get; }
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { 
                _students = value;
                OnPropertyChanged();
            }
        }


        public StudentsViewModel()
        {
            services = new DBFirebase();
            Students = services.getStudent();
            AddStudentCommand = new Command(async () => await addStudentAsync(Id, Description, Monto, Fecha, Recibo));
        }
    
    public async Task addStudentAsync(int Id,string Description,double Monto,DateTime Fecha, string Recibo)
        {
            await services.AddStudent(Id, Description, Monto, Fecha, Recibo);
        }


    }
}
