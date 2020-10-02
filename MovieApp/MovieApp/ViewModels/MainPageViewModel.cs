using System;
using System.Collections.Generic;
using MovieApp.Models;
using MovieApp.Views;

namespace MovieApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Root root;
        private List<Result> topRate;
        private List<Result> upcoming;
        private List<Result> popular;



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
            TopRate = new List<Result>();
            Upcoming = new List<Result>();
            Popular = new List<Result>();

            GetBannersAsync();
        }

        public async void GetBannersAsync()
        {
            IsLoading = true;
            TopRate = await root.GetTopRate();
            Upcoming = await root.GetUpconming();
            Popular = await root.GetPopular();
            IsLoading = false;
        }



        public async void NavigateDetailView(Result movie)
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailPage(movie), true);
        }
    }
}
