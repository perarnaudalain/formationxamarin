﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using deezerapp.Model.DtoUI;
using deezerapp.ServiceLayer;
using Xamarin.Forms;
using deezerapp.ServiceLayer.Playlist;
using deezerapp.Util;
using deezerapp.ServiceLayer.Exception;

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

        public PlaylistViewModel(int idDeezer)
        {
            playlistService = ServiceLocator.GetService<PlaylistService>();

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
    }
}