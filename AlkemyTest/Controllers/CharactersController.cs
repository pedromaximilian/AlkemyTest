using AlkemyTest.Data.Services;
using AlkemyTest.Data.ViewModels;
using AlkemyTest.QueryFiltesrs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlkemyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharactersController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/Characters
        [HttpGet]
        public IActionResult Get([FromQuery] CharacterFilter filter)
        {
            try
            {
                List<CharacterGetVM> chars = _characterService.GetAll(filter);
                return Ok(chars);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET api/Characters/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CharacterVM _character = _characterService.GetById(id);
            if (_character != null)
            {
                return Ok(_character);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Characters
        [HttpPost]
        public IActionResult PostCharacter(CharacterPostVM character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("check object properties");
            }

            try
            {
                //TODO: devuelve el ultimo id creado.
                int response = _characterService.Add(character);
                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Characters/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CharacterVM characterVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("check object properties");
            }
            try
            {
                string message = _characterService.Update(id, characterVM);

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

        // DELETE api/Characters/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string response = _characterService.Delete(id);
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
        [HttpPut("{id_c}/Movie/{id_m}")]
        public IActionResult PutMovie(int id_c, int id_m)
        {
            try
            {
                string message = _characterService.AddMovie(id_c, id_m);

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
        [HttpDelete("{id_c}/Movie/{id_m}")]
        public IActionResult DeleteMovie(int id_c, int id_m)
        {
            string response = _characterService.DeleteMovie(id_c, id_m);
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
