using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using deezerapp.Service;
using deezerapp.Model.DtoFromDeezer;

namespace unittest
{
    [TestFixture()]
    public class Tests
    {
        [Test()]
        public void Testdese()
        {
            PlaylistService playlistService = new PlaylistService();
            string content = "{ \"data\":[{\"id\":272040201,\"title\":\"Loved tracks\"}]}";
            PlaylistsModelDtoFromDeezer playlistsFromDeezer = playlistService.Deserialize(content);
            playlistsFromDeezer.playlists.First().Title.ShouldBeEquivalentTo("Loved tracks");
        }
    }
}
