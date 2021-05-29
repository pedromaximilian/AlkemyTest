using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Services
{
    public class CharacterService
    {
        private readonly DataContext _context;

        public CharacterService(DataContext context)
        {
            _context = context;
        }

        public void AddCharacter(CharacterVM character) {

            // Validamos nombres duplicados
            if (!_context.Characters.Any(t => t.Name.Equals(character.Name)))
            {
                //TODO: agregar peliculas
                try
                {
                    Character nuevo = new Character()
                    {
                        Image = character.Image,
                        Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(character.Name),
                        Weight = character.Weight,
                        Age = character.Age,
                        History = character.History
                        //nuevo.Casts = character.Casts;
                    };
                    _context.Characters.Add(nuevo);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                //Control de la excepcion SQL por nombre duplicado
                throw new();
            }


        }
    }
}
