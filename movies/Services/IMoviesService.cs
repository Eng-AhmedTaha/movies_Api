using movies.models;

namespace movies.Services
{
    public interface IMoviesService 
    {
        Task<IEnumerable<Movie>> getall();
        Task<Movie> getbyId(int id);
        Task<Movie> Add(Movie movie);
        Task<Movie> Update(Movie movie);
        Task<Movie> delete(Movie movie);

    }
}
