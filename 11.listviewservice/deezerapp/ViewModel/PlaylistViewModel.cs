using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using deezerapp.Model.DtoUI;
using deezerapp.Service;

namespace deezerapp.ViewModel
{
    public class PlaylistViewModel : INotifyPropertyChanged
    {
        PlaylistService playlistService;

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
            playlistService = new PlaylistService();

            Task.Run(async () =>
            {
                Playlists = await playlistService.GetPlaylist();
            });
        }
    }
}