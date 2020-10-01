using System;
using System.Collections.Generic;
using MovieApp.Models;
using MovieApp.ViewModels;
using Xamarin.Forms;

namespace MovieApp.Views
{
    public partial class DetailPage : ContentPage
    {
        private Result movie;

        public DetailViewModel ViewModel;


        public DetailPage(Result movie)
        {
            InitializeComponent();
            ViewModel = new DetailViewModel(movie);
            this.movie = movie;
        }
    }
}
