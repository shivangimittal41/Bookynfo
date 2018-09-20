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
        private ObservableCollection<FirstBookList_Class> _listOfISBN = new ObservableCollection<FirstBookList_Class>() { };

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await BookFetching();
            BookList.ItemsSource = _listOfISBN;
            Alternative.IsVisible = false;
            ////SearchBar.Text = null;
            //SearchBar.Text = "";
        }

        public MainPage()
        {
            InitializeComponent();
            //BookList.ItemsSource = await BookFetching();
            Category.SelectedIndex = 0;
        }

        private async void BookList_Refreshing(object sender, EventArgs e)
        {
            await BookFetching();
            BookList.ItemsSource = _listOfISBN;
            BookList.EndRefresh();
        }

        private async void BookList_ItemSelected(object sender,
            SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedBookNumber = e.SelectedItem as FirstBookList_Class;
            App.SelectedBookNumber = selectedBookNumber.ISBN_number;
            await Navigation.PushAsync(new Detail());
            BookList.SelectedItem = null;
            
        }


        private async Task<bool> BookFetching()
        {
            _listOfISBN.Clear();


            foreach (var isbn in ISBN_List_Class.GetISBN_List())

            {
                FirstRootObject listOfBooks = await FirstScreen_class.GetFirst_details(Convert.ToString(isbn), "ISBN");

                foreach (var item in listOfBooks.items)
                {
                    try
                    {
                        _listOfISBN.Add(
                        new FirstBookList_Class
                        {

                            smallthumbnail = (string.IsNullOrEmpty(item.volumeInfo.imageLinks.smallThumbnail)) ?
                                       "Null value" : Convert.ToString(item.volumeInfo.imageLinks.smallThumbnail),

                            category = (string.IsNullOrEmpty(string.Join(" ", item.volumeInfo.categories))) ?
                                        "cant access" : string.Join(" ", item.volumeInfo.categories),

                            PDFAvailable = (string.IsNullOrEmpty(Convert.ToString(item.accessInfo.pdf.isAvailable))) ?
                                        false : Convert.ToBoolean(item.accessInfo.pdf.isAvailable),

                            title = (string.IsNullOrEmpty(item.volumeInfo.title)) ?
                                        "not available" : Convert.ToString(item.volumeInfo.title).Trim(),
                            textSnippet = (string.IsNullOrEmpty(Convert.ToString(item.searchInfo.textSnippet))) ?
                                            "Not available" : Convert.ToString(item.searchInfo.textSnippet),
                            //textSnippet= item.searchInfo.textSnippet,
                            previewLink = (item.volumeInfo.previewLink == null) ?
                                        "not available" : Convert.ToString(item.volumeInfo.previewLink),
                            ID = item.id,
                            ISBN_number = (string.IsNullOrEmpty(String.Join(" ", item.volumeInfo.industryIdentifiers[0].identifier)) ?
                                "Not available" : String.Join(" ", item.volumeInfo.industryIdentifiers[0].identifier))
                            //ISBN_number = Convert.ToString(isbn)
                            //textSnippet= item.searchInfo.textSnippet


                    }
                        );
                    }
                    catch (Exception)
                    {

                        continue;
                    }

                }


            }

            return true;

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
                return;

            BookList.ItemsSource = _listOfISBN.Where(c => c.title.ToUpper().Contains(e.NewTextValue.ToUpper()));
            if (!BookList.ItemsSource.GetEnumerator().MoveNext())
            {
                Alternative.IsVisible = true;
                Alternative.Text = "Press Enter to look for the results";
                //DisplayAlert("Your search exists in another list", "Press Ok to go to the results", "Ok");
            }
            else
            {
                Alternative.IsVisible = false;
            }
        }

        private async void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category.SelectedIndex == 0 || Convert.ToString(Category.SelectedItem) == "All")
            {
                BookList.ItemsSource = _listOfISBN;
            }
            else
            BookList.ItemsSource = _listOfISBN.Where(c => c.category.Contains(Category.SelectedItem.ToString()));
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            await SearchedBookFetch(SearchBar.Text);
            BookList.ItemsSource = _listOfISBN;
            SearchBar.Text = "";
            Alternative.IsVisible = false;
        }
       

        private async Task SearchedBookFetch(string searchText)
        {
            FirstRootObject listOfBooks = await FirstScreen_class.GetFirst_details(searchText, "Text");
            _listOfISBN.Clear();
            foreach (var item in listOfBooks.items)
            {
                try
                {

                    _listOfISBN.Add(
                   new FirstBookList_Class
                   {

                       smallthumbnail = (string.IsNullOrEmpty(item.volumeInfo.imageLinks.smallThumbnail)) ?
                                  "Null value" : Convert.ToString(item.volumeInfo.imageLinks.smallThumbnail),

                       category = (string.IsNullOrEmpty(string.Join(" ", item.volumeInfo.categories))) ?
                                   "cant access" : string.Join(" ", item.volumeInfo.categories),

                       PDFAvailable = (string.IsNullOrEmpty(Convert.ToString(item.accessInfo.pdf.isAvailable))) ?
                                   false : Convert.ToBoolean(item.accessInfo.pdf.isAvailable),

                       title = (string.IsNullOrEmpty(item.volumeInfo.title)) ?
                                   "not available" : Convert.ToString(item.volumeInfo.title).Trim(),
                       textSnippet = (string.IsNullOrEmpty(Convert.ToString(item.searchInfo.textSnippet))) ?
                                       "Not available" : Convert.ToString(item.searchInfo.textSnippet),
                        
                        previewLink = (item.volumeInfo.previewLink == null) ?
                                   "not available" : Convert.ToString(item.volumeInfo.previewLink),
                       ID = item.id,
                       ISBN_number = (string.IsNullOrEmpty(String.Join(" ", item.volumeInfo.industryIdentifiers[0].identifier)) ?
                                "Not available" : String.Join(" ", item.volumeInfo.industryIdentifiers[0].identifier))
                       //textSnippet= item.searchInfo.textSnippet


                   }
                   );
                }
                catch (Exception)
                {
                    continue;
                   
                }

            }


        }

    }
   
}

