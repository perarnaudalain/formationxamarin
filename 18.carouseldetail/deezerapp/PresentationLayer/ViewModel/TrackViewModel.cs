using System;
using System.Collections.Generic;
using System.ComponentModel;
using deezerapp.Model.DtoUI;

namespace deezerapp.PresentationLayer.ViewModel
{
    public class TrackViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<PlaylistModelDtoUI> test;
        public List<PlaylistModelDtoUI> Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }

        public TrackViewModel(PlaylistModelDtoUI model)
        {
            List<PlaylistModelDtoUI> testalain = new List<PlaylistModelDtoUI>();
            testalain.Add(new PlaylistModelDtoUI("1", 2333));
            testalain.Add(new PlaylistModelDtoUI("1", 2333));
            testalain.Add(new PlaylistModelDtoUI("1", 2333));
            Test = testalain;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
