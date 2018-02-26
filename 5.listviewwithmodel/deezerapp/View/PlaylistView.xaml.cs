using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using deezerapp.Model;
using Xamarin.Forms;

namespace deezerapp.View
{
    public partial class PlaylistView : ContentPage
    {
        public PlaylistView()
        {
            InitializeComponent();

            ObservableCollection<PlaylistModel> Playlists = new ObservableCollection<PlaylistModel>();
            Playlists.Add(new PlaylistModel("playlist1", "00:03:54"));
            Playlists.Add(new PlaylistModel("playlist2", "00:13:54"));
            listView.ItemsSource = Playlists;
        }
    }
}
