using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace deezerapp.View
{
    public partial class PlaylistView : ContentPage
    {
        public PlaylistView()
        {
            InitializeComponent();

            listView.ItemsSource = new string[]{
                "playlist1",
                "playlist2",
                "playlist3",
                "playlist4",
                "playlist5",
                "playlist6",
                "playlist7",
                "playlist8",
                "playlist9"
            };
        }
    }
}
