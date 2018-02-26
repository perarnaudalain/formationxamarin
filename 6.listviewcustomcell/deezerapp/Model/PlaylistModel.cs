namespace deezerapp.Model
{
    public class PlaylistModel
    {
        public string Title { get; set; }
        public string Duration { get; set; }

        public PlaylistModel(string title, string duration) {
            this.Title = title;
            this.Duration = duration;
        }
    }
}