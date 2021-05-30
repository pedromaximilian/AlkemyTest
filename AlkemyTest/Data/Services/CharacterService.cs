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

        public int Add(CharacterVM character) {
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
                    return _character.Id;
                }
                catch (Exception ex)
                {
                    throw new(ex.Message);
                }
            }
            else
            {
                throw new("Duplicated Name");
            }


        }

        public CharacterVM GetById(int id)
        {
            var _character = _context.Characters.FirstOrDefault(t => t.Id == id);

            if (_character != null)
            {
                return new CharacterVM()
                {
                    Id = _character.Id,
                    Image = _character.Image,
                    Name = _character.Name,
                    Age = _character.Age,
                    Weight = _character.Weight,
                    History = _character.History
                };
            }
            else
            {
                return null;
            }


            
        }

        public List<CharacterVM> GetAll() {

            try
            {
                return _context.Characters.Select(p => new CharacterVM
                {
                    Image = p.Image,
                    Name = p.Name,
                    Age = p.Age,
                    Weight = p.Weight,
                    History = p.History
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }



        }

        public string Delete(int id)
        {
            var character = _context.Characters.Find(id);
            if (character == null)
            {
                return "Not Found";
            }

            _context.Characters.Remove(character);
            _context.SaveChangesAsync();

            return "Ok";
        }

        public String Update(int id,CharacterVM _character)
        {
            if (id != _character.Id)
            {
                return "Bad Request";
            }

            var character = new Character()
            {
                Id = _character.Id,
                Image = _character.Image,
                Name = _character.Name,
                Age = _character.Age,
                Weight = _character.Weight,
                History = _character.History
            };


            _context.Entry(character).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
                return "Ok";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return "Not Found";
                }
                else
                {
                    throw;
                }
            }

        }

        public List<CharacterNameImageVM> GetNameImage()
        {

            return _context.Characters.Select(p => new CharacterNameImageVM
            {
                Image = p.Image,
                Name = p.Name
            }).ToList();
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }



    }
}
