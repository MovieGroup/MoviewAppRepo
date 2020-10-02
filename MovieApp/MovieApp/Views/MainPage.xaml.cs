
using MovieApp.Models;
using MovieApp.ViewModels;
using Xamarin.Forms;

namespace MovieApp.Views
{
    public partial class MainPage : ContentPage
    {
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
    }
}
