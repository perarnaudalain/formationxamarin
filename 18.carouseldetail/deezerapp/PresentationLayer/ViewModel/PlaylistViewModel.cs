using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using deezerapp.Model.DtoUI;
using deezerapp.ServiceLayer;
using Xamarin.Forms;
using deezerapp.ServiceLayer.Playlist;
using deezerapp.Util;
using deezerapp.ServiceLayer.Exception;
using deezerapp.PresentationLayer.View;

namespace deezerapp.PresentationLayer.ViewModel
{
    public class PlaylistViewModel : INotifyPropertyChanged
    {
        PlaylistService playlistService;

        private PlaylistModelDtoUI itemSelected;
        public PlaylistModelDtoUI ItemSelected
        {
            get
            {
                return itemSelected;
            }
            set
            {
                itemSelected = value;

                if (itemSelected != null)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new TrackView(itemSelected));
                }
            }
        }

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

        public PlaylistViewModel(int idDeezer)
        {
            playlistService = ServiceLocator.GetService<PlaylistService>();

            if (true || playlistService.GetNumberPlaylistInCache() == 0)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        Playlists = await playlistService.GetPlaylist(idDeezer);
                    }
                    catch (AccessDeezerException)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Application.Current.MainPage.DisplayAlert("alert", "message", "OK");
                        });
                    }
                    catch (Exception)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Application.Current.MainPage.DisplayAlert("alert", "message", "OK");
                        });
                    }
                });
            }
            else
            {
                try
                {
                    Playlists = playlistService.GetPlaylistFromCache();
                }
                catch (Exception)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.DisplayAlert("alert", "message", "OK");
                    });
                }
            }
        }
    }
}