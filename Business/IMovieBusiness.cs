using IobMovieUserAPI.Domain.Utils;
using IobMovieUserAPI.Domain.ValueObjects;

namespace IobMovieUserAPI.Business
{
    public interface IMovieBusiness
    {
        MovieVO Create(MovieVO Movie);
        MovieVO FindByID(long id);
        List<MovieVO> FindAll();
        PagedSearchVO<MovieVO> FindWithPagedSearch(
            string title, string sortDirection, int pageSize, int page);
        MovieVO Update(MovieVO Movie);
        void Delete(long id);
    }
}
