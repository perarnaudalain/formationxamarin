using System.ComponentModel;
using System.Runtime.Serialization;

namespace deezerapp.Model.DtoFromDeezer
{
    [DataContract]
    public class PlaylistModelDtoFromDeezer
    {
        [DataMember(Name="title")]
        public string Title { get; set; }
        public int Duration { get; set; }

        public PlaylistModelDtoFromDeezer(string title, int duration) {
            this.Title = title;
            this.Duration = duration;
        }
    }
}