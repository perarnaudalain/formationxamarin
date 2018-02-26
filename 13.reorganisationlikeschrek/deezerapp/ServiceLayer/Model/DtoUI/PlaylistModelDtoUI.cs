using System;
namespace deezerapp.Model.DtoUI
{
    public class PlaylistModelDtoUI
    {
        public string Title { get; set; }
        public int Duration { get; set; }

        public PlaylistModelDtoUI(string title, int duration)
        {
            this.Title = title;
            this.Duration = duration;
        }
    }
}
