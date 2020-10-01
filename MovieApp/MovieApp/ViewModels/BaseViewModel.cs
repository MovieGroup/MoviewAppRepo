using System;
using System.ComponentModel;

namespace MovieApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            { isLoading = value; OnPropertyChanged("IsLoading"); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            { isBusy = value; OnPropertyChanged("IsBusy"); }
        }

    }
}
