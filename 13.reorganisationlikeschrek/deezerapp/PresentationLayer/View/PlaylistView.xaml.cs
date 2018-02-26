using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using deezerapp.Model;
using deezerapp.ViewModel;
using Xamarin.Forms;

namespace deezerapp.View
{
    public partial class PlaylistView : ContentPage
    {
        public PlaylistView(int idDeezer)
        {
            InitializeComponent();
            BindingContext = new PlaylistViewModel(idDeezer);
        }
    }
}
