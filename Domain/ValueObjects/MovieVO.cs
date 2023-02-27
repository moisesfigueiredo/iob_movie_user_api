namespace IobMovieUserAPI.Domain.ValueObjects
{
    public class MovieVO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}