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
            BindingContext = ViewModel;
            this.movie = movie;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
