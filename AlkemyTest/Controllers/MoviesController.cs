using AlkemyTest.Data.Services;
using AlkemyTest.Data.ViewModels;
using AlkemyTest.QueryFiltesrs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlkemyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult Get([FromQuery] MovieFilter filter)
        {
            try
            {
                List<MovieGetVM> _movies = _movieService.GetAll(filter);


                return Ok(_movies);

            }
            catch (Exception)
            {

                return NotFound();
            }



        }

        // GET api/Movies/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieVM _movie = _movieService.GetById(id);
            if (_movie != null)
            {
                return Ok(_movie);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/Movies
        [HttpPost]
        public IActionResult Post(MoviePostVM _movieVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("check object properties");
            }
            try
            {
                //TODO: devuelve el ultimo id creado.
                int response = _movieService.Add(_movieVM);
                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, MovieVM _movieVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("check object properties");
            }
            try
            {
                string message = _movieService.Update(id, _movieVM);

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

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string response = _movieService.Delete(id);
            if (response.Equals("Ok"))
            {
                return Ok();
            }
            else
            {
                return BadRequest(response);
            }
        }



        // PUT api/Characters/5/Movie/
        [HttpPut("{id_m}/Character/{id_c}")]
        public IActionResult PutMovie(int id_m, int id_c)
        {
            try
            {
                string message = _movieService.AddCharacter(id_c, id_m);

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

        // DELETE api/Characters/5/Movie/1
        [HttpDelete("{id_m}/Character/{id_c}")]
        public IActionResult DeleteMovie(int id_m, int id_c)
        {
            string response = _movieService.DeleteCharacter(id_m, id_c);
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
