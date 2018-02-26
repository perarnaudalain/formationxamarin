using System;
using System.Collections.Generic;
using deezerapp.Model.DtoUI;
using deezerapp.PresentationLayer.ViewModel;
using Xamarin.Forms;

namespace deezerapp.PresentationLayer.View
{
    public partial class TrackView : CarouselPage
    {
        public TrackView(PlaylistModelDtoUI model)
        {
            InitializeComponent();
            BindingContext = new TrackViewModel(model);
        }
    }
}
