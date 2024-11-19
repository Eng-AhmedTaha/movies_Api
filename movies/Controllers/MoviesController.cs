using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Dots;
using movies.models;
using movies.Services;

namespace movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
       private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
           _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movie = await _moviesService.getall();

            return Ok(movie);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var movie = await _moviesService.getbyId(id);

            return Ok(movie);
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] MovieDto dto)
        {
            using var datastream = new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);
            Movie movie = new Movie()
            {
                Title = dto.Title,
                Year = dto.Year,
                Rate = dto.Rate,
                GenreId = dto.GenreId,
                Storeline = dto.Storeline,
                Poster = datastream.ToArray()
            };

            await _moviesService.Add(movie);   
            return Ok(movie);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] MovieDto dto)
        {

            var movie = await _moviesService.getbyId(id);

            if (dto.Poster != null)
            {
                using var datastream = new MemoryStream();
                await dto.Poster.CopyToAsync(datastream);
                movie.Poster = datastream.ToArray();
            }




            movie.Title = dto.Title;
            movie.Year = dto.Year;
            movie.Rate = dto.Rate;
            movie.Storeline = dto.Storeline;
              movie.GenreId  = dto.GenreId;


           await _moviesService.Update(movie);
            return Ok(movie);   
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie = await _moviesService.getbyId(id);

          await  _moviesService.delete(movie);
            return Ok(movie);

        }

    }
}
