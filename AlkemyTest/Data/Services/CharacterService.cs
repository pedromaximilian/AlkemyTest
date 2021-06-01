using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AlkemyTest.Data.Services
{
    public class CharacterService
    {
        private readonly DataContext _context;

        public CharacterService(DataContext context)
        {
            _context = context;
        }

        public int Add(CharacterVM character)
        {
            // duplicated name validation
            if (!_context.Characters.Any(t => t.Name.Equals(character.Name)))
            {
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
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new("Duplicated Name");
            }


        }

        public List<CharacterVM> GetAll()
        {
            //TODO: no esta en los requerimientos, eliminar?
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

        public CharacterVM GetById(int id)
        {
            try
            {
                CharacterVM _characterVM = _context.Characters.Where(n => n.Id == id)
                    .Select(c => new CharacterVM()
                    {
                        Id = c.Id,
                        Image = c.Image,
                        Name = c.Name,
                        Age = c.Age,
                        Weight = c.Weight,
                        History = c.History,
                        Movies = c.Character_Movies.Select(cm => new MovieVM()
                        {
                            Id = cm.Movie.Id,
                            Image = cm.Movie.Image,
                            Title = cm.Movie.Title,
                            CreatedAt = cm.Movie.CreatedAt,
                            Qualification = cm.Movie.Qualification,
                            Genres = cm.Movie.Movie_Genres.Select(mg => new GenreVM()
                            {
                                Id = mg.Genre.Id,
                                Image = mg.Genre.Image,
                                Name = mg.Genre.Name
                            }).ToList()
                        }).ToList()
                    }).FirstOrDefault();
                return _characterVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Delete(int id)
        {
            Character character = _context.Characters.Find(id);
            if (character == null)
            {
                return "Not Found";
            }
            _context.Characters.Remove(character);
            _context.SaveChangesAsync();
            return "Ok";
        }

        public string Update(int id, CharacterVM _character)
        {
            if (id != _character.Id)
            {
                return "Bad Request";
            }

            Character character = new Character()
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

        public List<CharacterGetVM> GetNameImage()
        {

            return _context.Characters.Select(p => new CharacterGetVM
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
