using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using deezerapp.Model;
using deezerapp.View;
using Xamarin.Forms;

namespace deezerapp.ViewModel
{
    public class PlaylistViewModel : INotifyPropertyChanged
    {
        ObservableCollection<PlaylistModel> _playlists;
        public ObservableCollection<PlaylistModel> Playlists 
        {
            get 
            {
                return _playlists;    
            }
            set
            {
                _playlists = value;
                OnPropertyChanged("Playlists");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PlaylistViewModel() {
            ObservableCollection<PlaylistModel> playlists = new ObservableCollection<PlaylistModel>();
            playlists.Add(new PlaylistModel("playlist1", "00:03:54"));
            playlists.Add(new PlaylistModel("playlist2playlist2", "00:13:54"));
            Playlists = playlists;

            Task.Run(async () =>
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("https://api.deezer.com/user/100/playlists");
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
            });
        }
    }
}