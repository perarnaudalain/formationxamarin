using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using deezerapp.Model;
using deezerapp.PresentationLayer.ViewModel;
using Xamarin.Forms;

namespace deezerapp.PresentationLayer.View
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
