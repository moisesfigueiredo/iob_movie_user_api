using Domain.Entitites;
using IobMovieUserAPI.Data.Converter.Contract;
using IobMovieUserAPI.Domain.ValueObjects;

namespace IobMovieUserAPI.Data.Converter.Implementations
{
    public class MovieConverter : IParser<MovieVO, Movie>, IParser<Movie, MovieVO>
    {
        public Movie Parse(MovieVO origin)
        {
            if (origin == null) return null;
            return new Movie
            {
                Id = origin.Id,
                Director = origin.Director,
                ReleaseDate = origin.ReleaseDate,
                Year = origin.Year,
                Title = origin.Title
            };
        }

        public MovieVO Parse(Movie origin)
        {
            if (origin == null) return null;
            return new MovieVO
            {
                Id = origin.Id,
                Director = origin.Director,
                ReleaseDate = origin.ReleaseDate,
                Year = origin.Year,
                Title = origin.Title
            };
        }

        public List<Movie> Parse(List<MovieVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<MovieVO> Parse(List<Movie> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
