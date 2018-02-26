using System;
using System.Collections.Generic;
using System.IO;
using deezerapp.DataLayer.Entity;
using PCLStorage;
using SQLite;

namespace deezerapp.DataLayer
{
    public class Database
    {
        private static SQLiteConnection _conn;

        public SQLiteConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                    IFolder folder = FileSystem.Current.LocalStorage;
                    string folder_path = folder.Path.ToString();
                    _conn = new SQLiteConnection(Path.Combine(folder_path, "db.sqlite"));
                    _conn.CreateTable<PlaylistEntity>();
                }
                return _conn;
            }
        }

        public void Save(List<PlaylistEntity> playlistsEntity)
        {
            Conn.RunInTransaction(() =>
            {
                Conn.DeleteAll<PlaylistEntity>();
                foreach (PlaylistEntity playListEntity in playlistsEntity)
                {
                    Conn.InsertOrReplace(playListEntity);
                }
            });
        }

        public IEnumerable<PlaylistEntity> GetPlaylistsEntity()
        {
            IEnumerable<PlaylistEntity> ple = Conn.Table<PlaylistEntity>();
            return ple;
        }

        public int GetNumberPlaylist() {
            return Conn.ExecuteScalar<int>("Select count(*) From PlaylistEntity");
        }
    }
}
