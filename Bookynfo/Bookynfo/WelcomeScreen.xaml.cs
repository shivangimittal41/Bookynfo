using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookynfo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomeScreen : ContentPage
	{
            

        public WelcomeScreen ()
		{
			InitializeComponent ();
		}


        private void OnClicked(object sender, EventArgs e)
        {
            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MainPage());
            //this.Navigate(new MainPage());
            Navigation.PushAsync(new MainPage());
        }


    }
}