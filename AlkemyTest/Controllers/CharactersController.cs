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
                _characterService.AddCharacter(character);
                //TODO: podria devolver el ultimo id creado.
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Transacción Inválida");
            }
        }
    }
}
