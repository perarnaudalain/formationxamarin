using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using deezerapp.Model.DtoFromDeezer;
using deezerapp.Model.DtoUI;
using Newtonsoft.Json;

namespace deezerapp.ViewModel
{
    public class PlaylistViewModel : INotifyPropertyChanged
    {
        ObservableCollection<PlaylistModelDtoUI> _playlists;
        public ObservableCollection<PlaylistModelDtoUI> Playlists
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

        public PlaylistViewModel()
        {
            Task.Run(async () =>
            {
                // request
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("https://api.deezer.com/user/100/playlists");
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                // deserialise
                PlaylistsModelDtoFromDeezer playlistsFromDeezer = JsonConvert.DeserializeObject<PlaylistsModelDtoFromDeezer>(content);

                // Tranform dtofromschrek to dtoui
                ObservableCollection<PlaylistModelDtoUI> playlists = new ObservableCollection<PlaylistModelDtoUI>();
                foreach (PlaylistModelDtoFromDeezer playlist in playlistsFromDeezer.playlists)
                {
                    PlaylistModelDtoUI playlistModelDtoUI = new PlaylistModelDtoUI(playlist.Title, playlist.Duration);
                    playlists.Add(playlistModelDtoUI);
                }
                Playlists = playlists;
            });
        }
    }
}