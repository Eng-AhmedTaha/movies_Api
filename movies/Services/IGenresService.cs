using Microsoft.AspNetCore.Mvc;
using movies.Dots;
using movies.models;

namespace movies.Services
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> getall();
        Task<Genre> getbyId(int id);
        Task<Genre> Add(Genre genre);
        Task<Genre> Update(Genre genre);
        Task<Genre> delete(Genre genre);
    }
}
