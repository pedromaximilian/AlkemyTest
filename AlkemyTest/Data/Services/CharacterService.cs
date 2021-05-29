using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public void Add(CharacterVM character) {
            // duplicated name validation
            if (!_context.Characters.Any(t => t.Name.Equals(character.Name)))
            {
                //TODO: agregar peliculas
                try
                {
                    Character _character = new Character()
                    {
                        Image = character.Image,
                        Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(character.Name),
                        Weight = character.Weight,
                        Age = character.Age,
                        History = character.History
                    };
                    _context.Characters.Add(_character);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new();
            }


        }

        public List<CharacterVM> GetAll() {
        
            return  _context.Characters.Select(p => new CharacterVM
            {
                Image = p.Image,
                Name = p.Name,
                Age = p.Age,
                Weight = p.Weight,
                History = p.History
            }).ToList();
        }

        public List<CharacterNameImageVM> GetNameImage()
        {

            return _context.Characters.Select(p => new CharacterNameImageVM
            {
                Image = p.Image,
                Name = p.Name
            }).ToList();
        }



    }
}
