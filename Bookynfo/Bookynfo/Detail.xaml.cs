using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookynfo.Info;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Bookynfo.LocalData;
using Bookynfo.Info;

namespace Bookynfo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
        private ObservableCollection<DetailsPage_Class> _DetailsofBook = new ObservableCollection<DetailsPage_Class> { };
        //private string currentSelectedID;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            await BookDetailsFetching();
        }

        public Detail ()
		{
			InitializeComponent ();
		}

       
        private async Task BookDetailsFetching()
        {
            Clicked_RootObject detailsOfBooks = await ClickedScreen_class.GetClicked_details(App.SelectedBookNumber, "ISBN");
            _DetailsofBook.Clear();
            foreach( var item in detailsOfBooks.items)
            {
                try
                {
                    BookTitle.Text = (string.IsNullOrEmpty(item.volumeInfo.title) ?
                   "Not available" : item.volumeInfo.title);

                    BookImage.Source = (string.IsNullOrEmpty(item.volumeInfo.imageLinks.thumbnail) ?
                        "Not available" : item.volumeInfo.imageLinks.thumbnail);


                    //Bookid.Text = (string.IsNullOrEmpty(Convert.ToString(item.id)) ?
                    //    "Not available" : Convert.ToString(item.id));

                    PDFavailable.Text = (string.IsNullOrEmpty(Convert.ToString(item.accessInfo.pdf.isAvailable)) ?
                        "Not available" : Convert.ToString(item.accessInfo.pdf.isAvailable));

                    Booklanguage.Text = (string.IsNullOrEmpty(item.volumeInfo.language) ?
                        "Not available" : item.volumeInfo.language);

                    BookaverageRating.Text = (string.IsNullOrEmpty(Convert.ToString(item.volumeInfo.averageRating)) ?
                        "Not available" : Convert.ToString(item.volumeInfo.averageRating));

                    BookpageCount.Text = (string.IsNullOrEmpty(Convert.ToString(item.volumeInfo.pageCount)) ?
                        "Not available" : Convert.ToString(item.volumeInfo.pageCount));

                    BookDescription.Text = (string.IsNullOrEmpty(item.volumeInfo.description) ?
                        "Not available" : item.volumeInfo.description);

                    Bookauhtor.Text = (string.IsNullOrEmpty(String.Join(" ", item.volumeInfo.authors)) ?
                        "Not available" : String.Join(" ", item.volumeInfo.authors));
                    ISBN.Text = (string.IsNullOrEmpty(String.Join(" ", item.volumeInfo.industryIdentifiers[0].identifier)) ?
                        "Not available" : String.Join(" ", item.volumeInfo.industryIdentifiers[0].identifier));
                }
                catch (Exception)
                {
                    continue;
                
                }
                            
    }

        }
    }
}
 