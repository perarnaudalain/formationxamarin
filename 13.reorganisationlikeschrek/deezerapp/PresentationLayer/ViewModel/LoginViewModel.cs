using System;
using System.ComponentModel;
using System.Windows.Input;
using deezerapp.View;
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
                OnPropertyChanged("IdDeezer");
            }
        }

        public ICommand LoginCommand { protected set; get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                if(IdDeezer == null || IdDeezer.Equals("")) 
                {
                    await Application.Current.MainPage.DisplayAlert("alert", "pas de id deezer", "Ok");
                }
                else
                {
                    Application.Current.MainPage = new PlaylistView(Int32.Parse(IdDeezer));
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
