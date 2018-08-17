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
            
            await BookDeatilsFetching();
        }

        public Detail ()
		{
			InitializeComponent ();
		}


        private async Task BookDeatilsFetching()
        {
            Clicked_RootObject detailsOfBooks = await ClickedScreen_class.GetClicked_details();
            _DetailsofBook.Clear();
            foreach( var item in detailsOfBooks.items)
            {
                BookTitle.Text = item.volumeInfo.title;
                //_DetailsofBook.Add(new DetailsPage_Class
                //{
                //    id = currentSelectedID,
                //    PDFavailable= item.accessInfo.pdf.isAvailable,
                //    language = item.volumeInfo.language,
                //    averageRating = item.volumeInfo.averageRating,
                //    pageCount = item.volumeInfo.pageCount,
                //    description = item.volumeInfo.description,
                //    auhtor= String.Join(" ", item.volumeInfo.authors),
                //    thumbnail= item.volumeInfo.imageLinks.thumbnail

                //});





                //detailsOfBooks.ItemsSource = _DetailsofBook;

            }

}
    }
}