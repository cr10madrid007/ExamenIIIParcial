using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using examenIIP.Models;
using Firebase.Database;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace examenIIP.Services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://exameniiipmovil2-default-rtdb.firebaseio.com/");
        }

        

        public ObservableCollection<Student> getStudent()
        {
            var studentData = client
                .Child("Students")
                .AsObservable<Student>()
                .AsObservableCollection();
            return studentData;
        }
        public async Task AddStudent(int id, string description, double monto, DateTime fecha, string recibo)
        {
            Student s = new Student() { Id = id, Description = description, Monto = monto, Fecha = fecha, Recibo = recibo };
            await client
                .Child("Students")
                .PostAsync(s);
        }
        
        public async Task DeleteStudent(int id, string description, double monto, DateTime fecha, string recibo)
        {
            var toDeleteStudent = (await client
                .Child("Students")
                .OnceAsync<Student>()).LastOrDefault
                (a => a.Object.Id == id || a.Object.Description == description || a.Object.Monto == monto || a.Object.Fecha == fecha || a.Object.Recibo == recibo);
                await client.Child("Students").Child(toDeleteStudent.Key).DeleteAsync();
        }

        public async Task UpdateStudent(int id, string description, double monto, DateTime fecha, string recibo)
        {
            var toUpdateStudent = (await client
                .Child("Students")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.Id == id);

            Student s = new Student() { Id = id, Description = description, Monto = monto, Fecha = fecha, Recibo = recibo };
            await client
                .Child("Students")
                .Child(toUpdateStudent.Key)
                .PutAsync(s);
        }
    
    
    
    
    }
}
