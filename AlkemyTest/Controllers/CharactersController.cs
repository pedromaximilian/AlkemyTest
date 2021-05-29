using AlkemyTest.Data;
using AlkemyTest.Data.Services;
using AlkemyTest.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        private readonly CharacterService _characterService;

        public CharactersController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        // POST: api/Characters
        [HttpPost]
        public IActionResult PostCharacter(CharacterVM character)
        {
            try
            {
                _characterService.Add(character);
                //TODO: podria devolver el ultimo id creado.
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Transacción Inválida");
            }
        }

        // GET: api/Characters
        [HttpGet]
        public  IActionResult Get()
        {
            try
            {
                var chars = _characterService.GetNameImage();
                return Ok(chars);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        // GET api/Characters/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Characters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Characters/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
