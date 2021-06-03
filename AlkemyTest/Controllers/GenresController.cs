using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlkemyTest.Data;
using AlkemyTest.Data.Models;
using AlkemyTest.Data.Services;
using AlkemyTest.Data.ViewModels;

namespace AlkemyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreService _genreService;

        public GenresController(GenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genres
        [HttpGet]
        public IActionResult GetGenres()
        {
            return Ok(_genreService.GetAll());
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var genre = _genreService.GetById(id);

            if (genre != null)
            {
                return Ok(genre);
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, GenreVM genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            try
            {
                string message = _genreService.Update(id, genre);

                if (message.Equals("Ok"))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        // POST: api/Genres
        [HttpPost]
        public IActionResult PostGenre(GenreVM genre)
        {
            try
            {
                int response = _genreService.Add(genre);
                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var response = _genreService.Delete(id);
            if (response.Equals("Ok"))
            {
                return Ok();
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}
