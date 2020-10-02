
using MovieApp.Models;
using MovieApp.ViewModels;
using Xamarin.Forms;

namespace MovieApp.Views
{
    public partial class MainPage : ContentPage
    {
        bool isSearch = false;
        public MainPageViewModel ViewModel;

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();
            BindingContext = ViewModel;
        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            ImageButton snder = (ImageButton)sender;

            var x = (Result)snder.BindingContext;

            ViewModel.NavigateDetailView((Result)snder.BindingContext);

        }

        void Lista_Marcas_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ListView snder = (ListView)sender;

            var x = (Result)snder.BindingContext;

            ViewModel.NavigateDetailView((Result)snder.BindingContext);
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            if (searchBar == null || searchBar.Text == null)
                return;

            if (searchBar.Text.Length >= 3)
            {
                isSearch = true;
                ViewModel.Search(searchBar.Text.ToLower());
            }
            else if (searchBar.Text.Length == 0 && isSearch)
            {
                isSearch = false;
                ViewModel.RemoveSearch();
            }

        }
    }
}
