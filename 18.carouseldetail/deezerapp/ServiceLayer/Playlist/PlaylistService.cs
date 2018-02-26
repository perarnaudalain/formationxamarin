using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using deezerapp.Model.DtoFromDeezer;
using deezerapp.Model.DtoUI;
using Newtonsoft.Json;
using deezerapp.ServiceLayer.Exception;
using deezerapp.Util;
using deezerapp.DataLayer.Entity;
using deezerapp.DataLayer;

namespace deezerapp.ServiceLayer.Playlist
{
    public class PlaylistService
    {
        public PlaylistsModelDtoFromDeezer Deserialize(string content) {
            return JsonConvert.DeserializeObject<PlaylistsModelDtoFromDeezer>(content);
        }

        public int GetNumberPlaylistInCache() {
            return ServiceLocator.GetService<Database>().GetNumberPlaylist();
        }

        public async Task<ObservableCollection<PlaylistModelDtoUI>> GetPlaylist(int idDeezer) 
        {
            try
            {
                // request
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("https://api.deezer.com/user/"+idDeezer+"/playlists");
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                // deserialise
                PlaylistsModelDtoFromDeezer playlistsFromDeezer = Deserialize(content);

                // transform dtofromschrek to entity
                List<PlaylistEntity> playlistsEnity = new List<PlaylistEntity>();
                foreach (PlaylistModelDtoFromDeezer playlist in playlistsFromDeezer.playlists)
                {
                    PlaylistEntity playlistEntity = new PlaylistEntity();
                    playlistEntity.Title = playlist.Title;
                    playlistEntity.Duration = playlist.Duration;
                    playlistsEnity.Add(playlistEntity);
                }

                // Save Entity
                ServiceLocator.GetService<Database>().Save(playlistsEnity);


                return GetPlaylistFromCache();
            }
            catch(HttpRequestException) 
            {
                throw new AccessDeezerException();
            }
        }

        public ObservableCollection<PlaylistModelDtoUI> GetPlaylistFromCache() {
            // Get Entity
            IEnumerable<PlaylistEntity> entitys = ServiceLocator.GetService<Database>().GetPlaylistsEntity();

            // Transform entity to dtoui
            ObservableCollection<PlaylistModelDtoUI> playlists = new ObservableCollection<PlaylistModelDtoUI>();
            foreach (PlaylistEntity playlist in entitys)
            {
                PlaylistModelDtoUI playlistModelDtoUI = new PlaylistModelDtoUI(playlist.Title, playlist.Duration);
                playlists.Add(playlistModelDtoUI);
            }

            return playlists;
        }
    }
}
