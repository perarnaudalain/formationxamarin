using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using deezerapp.Model.DtoFromDeezer;
using deezerapp.Model.DtoUI;
using Newtonsoft.Json;

namespace deezerapp.Service
{
    public class PlaylistService
    {
        public async Task<ObservableCollection<PlaylistModelDtoUI>> GetPlaylist(int idDeezer) 
        {
            try
            {
                // request
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("https://api.deezer.com/user/"+idDeezer+"/playlists");
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                // deserialise
                PlaylistsModelDtoFromDeezer playlistsFromDeezer = JsonConvert.DeserializeObject<PlaylistsModelDtoFromDeezer>(content);

                // Tranform dtofromschrek to dtoui
                ObservableCollection<PlaylistModelDtoUI> playlists = new ObservableCollection<PlaylistModelDtoUI>();
                foreach (PlaylistModelDtoFromDeezer playlist in playlistsFromDeezer.playlists)
                {
                    PlaylistModelDtoUI playlistModelDtoUI = new PlaylistModelDtoUI(playlist.Title, playlist.Duration);
                    playlists.Add(playlistModelDtoUI);
                }

                return playlists;
            }
            catch(HttpRequestException) 
            {
                throw new AccessDeezerException();
            }
        }
    }
}
