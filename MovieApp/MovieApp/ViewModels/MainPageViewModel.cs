using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MovieApp.Models;
using Xamarin.Forms;
using MovieApp.Views;
using System.Threading.Tasks;
using MovieApp.ViewModels.CommandsViewModel;

namespace MovieApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Root root;
        public DetailNavigationCommand DetailNavCommand { get; set; }
        private List<Result> topRate;
        private List<Result> upcoming;
        private List<Result> popular;

        private List<Result> topRateCopy;
        private List<Result> upcomingCopy;
        private List<Result> popularcoPY;

        public ObservableCollection<Result> topprueba = new ObservableCollection<Result>();



        public List<Result> TopRate
        {
            get { return topRate; }
            set
            { topRate = value; OnPropertyChanged("TopRate"); }
        }

        public List<Result> Upcoming
        {
            get { return upcoming; }
            set
            { upcoming = value; OnPropertyChanged("Upcoming"); }
        }

        public List<Result> Popular
        {
            get { return popular; }
            set
            { popular = value; OnPropertyChanged("Popular"); }
        }


        public MainPageViewModel()
        {
            root = new Root();
            DetailNavCommand = new DetailNavigationCommand(this);
            TopRate = new List<Result>();
            Upcoming = new List<Result>();
            Popular = new List<Result>();

            GetBannersAsync();
        }

        public async void GetBannersAsync()
        {
            IsLoading = true;
            topRateCopy = await root.GetTopRate();
            TopRate = topRateCopy;

            upcomingCopy = await root.GetUpconming();
            Upcoming = upcomingCopy;

            popularcoPY = await root.GetPopular();
            Popular = popularcoPY;

            IsLoading = false;
        }



        public async void NavigateDetailView(Result movie)
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailPage(movie), true);
        }


        public async void Search(string filter)
        {
            await Device.InvokeOnMainThreadAsync(() =>
             {
                 TopRate = topRateCopy.FindAll(x => x.original_title.ToLower().Contains(filter)) as List<Result>;
                 Upcoming = upcomingCopy.FindAll(x => x.original_title.ToLower().Contains(filter)) as List<Result>;
                 Popular = popularcoPY.FindAll(x => x.original_title.ToLower().Contains(filter)) as List<Result>;
             });

        }

        public async void RemoveSearch()
        {
            await Device.InvokeOnMainThreadAsync(() =>
            {
                TopRate = topRateCopy;
                Upcoming = upcomingCopy;
                Popular = popularcoPY;
            });
        }

    }
}
