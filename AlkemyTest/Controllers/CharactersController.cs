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
        public IActionResult Get(int id)
        {
            var _character = _characterService.GetById(id);
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
        public IActionResult PostCharacter(CharacterVM character)
        {
            try
            {
                //TODO: podria devolver el ultimo id creado.
                var response = _characterService.Add(character);

                    return Ok(new {id = response });

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
            try
            {
                var message = _characterService.Update(id, characterVM);

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

            var response = _characterService.Delete(id);

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
