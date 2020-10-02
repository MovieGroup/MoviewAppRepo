using System;
using System.Collections.Generic;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        Example data = new Example();
        CastClass datacast = new CastClass();

        private Example companies;
        private List<Cast> casts;

        private Result movie;
        public Result Movie
        {
            get { return movie; }
            set
            { movie = value; OnPropertyChanged("Movie"); }
        }
        public Example Companies
        {
            get { return companies; }
            set
            { companies = value; OnPropertyChanged("Companies"); }
        }

        public List<Cast> Casts
        {
            get { return casts; }
            set
            { casts = value; OnPropertyChanged("Casts"); }
        }


        public DetailViewModel(Result movie)
        {
            Movie = movie;
            GetCompanies();
            GetCredits();

        }

        async void GetCompanies()
        {
            Companies = await data.GetDetail(Movie.id.ToString());
        }

        async void GetCredits()
        {
            Casts = (List<Cast>)await datacast.GetCredits(Movie.id.ToString());
        }
    }
}
