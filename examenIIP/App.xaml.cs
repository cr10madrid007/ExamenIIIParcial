using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace examenIIP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage (new  Views.StudentsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
