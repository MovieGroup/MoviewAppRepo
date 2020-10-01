
using MovieApp.ViewModels;
using Xamarin.Forms;

namespace MovieApp.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel VM;
        public MainPage()
        {
            InitializeComponent();
            VM = new MainPageViewModel();
            this.BindingContext = VM;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            //Root root = new Root();
            //List<Result> a = await root.GetTopRate();
            //List<Result> b = await root.GetUpconming();
            //List<Result> c = await root.GetPopular();
            //string k = "";
            // await Navigation.PushModalAsync(new DetailPage());

        }
    }
}
