using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Bookynfo.Info;
using Bookynfo.LocalData;

namespace Bookynfo
{
	public partial class MainPage : ContentPage
	{
        private ObservableCollection<FirstBookList_Class> _listOfISBN = new ObservableCollection<FirstBookList_Class> { };
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await BookFetching();
        }
              

        public MainPage()
		{
			InitializeComponent();
		}
        
        private async void BookList_Refreshing(object sender, EventArgs e)
        {
            await BookFetching();
            BookList.EndRefresh();
        }

        private async void BookList_ItemSelected(object sender,
            SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedRequest = e.SelectedItem as FirstScreen_class;
            //App.currentSelectedSurveyID = selectedRequest.id;
            await Navigation.PushAsync(new Detail());
            BookList.SelectedItem = null;
        }


        private async Task BookFetching()
        {
            foreach (var isbn in ISBN_List_Class.GetISBN_List())
                
            {
                FirstRootObject listOfBooks = await FirstScreen_class.GetFirst_details(Convert.ToInt64(isbn));
                _listOfISBN.Clear();
                //Console.WriteLine("Item Count : " + listOfBooks.items.Count());
                Console.WriteLine("Item ID : " + listOfBooks.items[0].id);
                //_listOfISBN.Add(
                //    new FirstBookList_Class
                //    {
                //        previewLink = "1",
                //        title = "1",
                //        category = string.Join(" ", listOfBooks.items[0].volumeInfo.categories),
                //        PDFAvailable = true,
                //        smallthumbnail = "1"
                //    }
                //    );

                //_listOfISBN.Add(
                //        new FirstBookList_Class
                //        {

                //            smallthumbnail = (listOfBooks.items[0].volumeInfo.imageLinks.smallThumbnail == null)?
                //           "Null value": Convert.ToString(listOfBooks.items[0].volumeInfo.imageLinks.smallThumbnail),

                //            category = (listOfBooks.items[0].volumeInfo.categories == null)?
                //            "cant access":string.Join(" ", listOfBooks.items[0].volumeInfo.categories),

                //            PDFAvailable = (listOfBooks.items[0].accessInfo.pdf.isAvailable == false)?
                //            false: Convert.ToBoolean(listOfBooks.items[0].accessInfo.pdf.isAvailable),

                //            title = (listOfBooks.items[0].volumeInfo.title == null)?
                //            "not available":Convert.ToString(listOfBooks.items[0].volumeInfo.title),

                //            previewLink = (listOfBooks.items[0].volumeInfo.previewLink == null)?
                //            "not available":Convert.ToString(listOfBooks.items[0].volumeInfo.previewLink)
                //        }
                //        );




                foreach (var item in listOfBooks.items)
                {
                    _listOfISBN.Add(
                        new FirstBookList_Class
                        {
                            smallthumbnail = Convert.ToString(item.volumeInfo.imageLinks.smallThumbnail),
                            
                            category = string.Join(" ", item.volumeInfo.categories),
                           
                            PDFAvailable = Convert.ToBoolean(item.accessInfo.pdf.isAvailable),
                            title = Convert.ToString(item.volumeInfo.title),
                            previewLink = Convert.ToString(item.volumeInfo.previewLink)
                        }
                        );
                    //console.writeline("item links : " + item.volumeinfo.imagelinks.smallthumbnail);
                }


            }

            BookList.ItemsSource = _listOfISBN;
        }
    }
}

