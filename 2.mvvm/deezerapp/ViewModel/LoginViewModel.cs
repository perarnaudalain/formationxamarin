using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace deezerapp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        String _idDeezer;

        public String IdDeezer
        {
            get 
            {
                return _idDeezer;    
            }
            set 
            {
                _idDeezer = value;
            }
        }

        public ICommand LoginCommand { protected set; get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(() =>
            {
                if(IdDeezer == null || IdDeezer.Equals("")) 
                {
                    Application.Current.MainPage.DisplayAlert("alert", "pas de id deezer", "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("alert", "mon id deezer : " + IdDeezer, "Ok");
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
