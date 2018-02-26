using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace deezerapp.Model.DtoFromDeezer
{
    [DataContract]
    public class PlaylistsModelDtoFromDeezer
    {
        [DataMember(Name = "data")]
        public List<PlaylistModelDtoFromDeezer> playlists { get; set; }
    }
}
