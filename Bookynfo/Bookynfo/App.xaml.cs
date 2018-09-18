using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Bookynfo
{
   
    public partial class App : Application
	{
        public static string URL = " https://www.googleapis.com/books/v1/volumes?q=";
        public static string SelectedBookNumber;
        //public static string SearchBookName;
        //public static int ISBN;
        public App ()
		{
			InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new WelcomeScreen());

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
