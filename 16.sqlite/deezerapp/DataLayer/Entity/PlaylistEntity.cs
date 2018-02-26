using System;
using SQLite.Net.Attributes;

namespace deezerapp.DataLayer.Entity
{
    [Table("Playlist")]
    public class PlaylistEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public int Duration { get; set; }
    }
}
