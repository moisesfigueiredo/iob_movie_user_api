using Domain.Bases;
using Domain.Entitites;
using IobMovieUserAPI.Data.Converter.Implementations;
using IobMovieUserAPI.Domain.Utils;
using IobMovieUserAPI.Domain.ValueObjects;

namespace IobMovieUserAPI.Business.Implementations
{
    public class MovieBusinessImplementation : IMovieBusiness
    {

        private readonly IRepository<Movie> _repository;

        private readonly MovieConverter _converter;

        public MovieBusinessImplementation(IRepository<Movie> repository)
        {
            _repository = repository;
            _converter = new MovieConverter();
        }

        public List<MovieVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<MovieVO> FindWithPagedSearch(
            string title, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from movies p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title)) query = query + $" and p.title like '%{title}%' ";
            query += $" order by p.title {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from movies p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title)) countQuery = countQuery + $" and p.title like '%{title}%' ";

            var movies = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<MovieVO>
            {
                CurrentPage = page,
                List = _converter.Parse(movies),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public MovieVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public MovieVO Create(MovieVO movie)
        {
            var movieEntity = _converter.Parse(movie);
            movieEntity = _repository.Create(movieEntity);
            return _converter.Parse(movieEntity);
        }

        public MovieVO Update(MovieVO movie)
        {
            var movieEntity = _converter.Parse(movie);
            movieEntity = _repository.Update(movieEntity);
            return _converter.Parse(movieEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

