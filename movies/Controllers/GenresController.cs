
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Dots;
using movies.models;
using movies.Services;
using System.Linq;

namespace movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {


            var genre = await _genresService.getall();
            return Ok(genre);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var genre = await _genresService.getbyId(id); 
            return Ok(genre);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGenreDto dto)
        {
            Genre genre = new Genre()
            {
                Name = dto.Name
            };

         await     _genresService.Add(genre);
            return Ok(genre);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateGenreDto dto)
        {
            var genre = await _genresService.getbyId(id);

            genre.Name = dto.Name;

         await _genresService.Update(genre);
            return Ok(genre);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre = await _genresService.getbyId(id);

       await  _genresService.delete(genre);
            return Ok(genre);

        }
    }
}
