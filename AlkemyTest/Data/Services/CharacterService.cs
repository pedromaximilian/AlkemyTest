using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
using AlkemyTest.QueryFiltesrs;
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

        public int Add(CharacterPostVM character)
        {
            // duplicated name validation
            if (!_context.Characters.Any(t => t.Name.ToLower().Equals(character.Name.ToLower())))
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

        public List<CharacterGetVM> GetAll(CharacterFilter filter)
        {
            //TODO: no esta en los requerimientos, eliminar?
            try
            {
                if (filter.Age != 0 || filter.Name != null || filter.IdMovie !=0)
                {
                    var _characterVM = _context.Characters
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
                            Qualification = cm.Movie.Qualification
                        }).ToList()
                    }).ToList();

                    if (filter.Age != 0)
                    {
                        _characterVM = _characterVM.Where(t => t.Age == filter.Age).ToList();

                    }
                    if (filter.Name != null)
                    {

                        _characterVM = _characterVM.Where(t => t.Name.ToLower().Contains(filter.Name.ToLower())).ToList();

                    }
                    if (filter.IdMovie != 0)
                    {
                        _characterVM = _characterVM.Where(t => t.Movies.Any(n => n.Id == filter.IdMovie)).ToList();
                    }

                    var res = _characterVM.Select(t => new CharacterGetVM 
                    {
                        Image = t.Image,
                        Name = t.Name
                    }
                    ).ToList();

                    return res;

                }
                else
                {
                    return _context.Characters.Select(p => new CharacterGetVM

                {
                    Image = p.Image,
                    Name = p.Name,
                }).ToList();
                }

                
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
            try
            {
                if (!CharacterExists(id))
                {
                    return "Not Found";
                }
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
                _context.SaveChangesAsync();

                
                return "Ok";
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

        }


        public string AddMovie(int _CharacterId, int _MovieId)
        {
            try
            {
                var res = _context.Character_Movies.Where(t => t.CharacterId == _CharacterId && t.MovieId == _MovieId).FirstOrDefault();

                if (res == null)
                {

                    var _character_movie = new Character_Movie()
                    {
                        CharacterId = _CharacterId,
                        MovieId = _MovieId
                    };

                    var reresponse = _context.Character_Movies.Add(_character_movie);

                    var response2 =_context.SaveChanges();
                }
                return "Ok";  
            }
            catch (Exception)
            {

                throw;
            }
        }


        public string DeleteMovie(int CharacterId, int MovieId)
        {
            try
            {
                var res = _context.Character_Movies.Where(t => t.CharacterId == CharacterId && t.MovieId == MovieId).FirstOrDefault();

                if (res != null)
                {
                    _context.Character_Movies.Remove(res);
                    _context.SaveChanges();
                }
                return "Ok";
            }
            catch (Exception)
            {

                throw;
            }
        }


        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }



    }
}
