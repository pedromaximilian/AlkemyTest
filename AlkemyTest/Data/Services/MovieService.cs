using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
using AlkemyTest.QueryFiltesrs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlkemyTest.Data.Services
{
    public class MovieService
    {
        private readonly DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }

        public int Add(MovieVM movieVM)
        {
            // duplicated name validation
            if (!_context.Movies.Any(t => t.Title.Equals(movieVM.Title)))
            {
                try
                {
                    Movie _movie = new Movie()
                    {
                        Image = movieVM.Image,
                        Title = movieVM.Title,
                        CreatedAt = movieVM.CreatedAt,
                        Qualification = movieVM.Qualification
                    };
                    _context.Movies.Add(_movie);
                    _context.SaveChanges();
                    return _movie.Id;
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

        public List<MovieGetVM> GetAll(MovieFilter filter)
        {
            try
            {

                if (filter.Name != null || filter.Order != null || filter.GenreId != 0)
                {
                    var _movies = _context.Movies.Select(t => new MovieVM
                    {
                        Id = t.Id,
                        Image = t.Image,
                        Title = t.Title,
                        CreatedAt = t.CreatedAt,
                        Qualification = t.Qualification,
                        Genres = t.Movie_Genres.Select(mg => new GenreVM()
                        {
                            Id = mg.Genre.Id,
                            Name = mg.Genre.Name,
                            Image = mg.Genre.Image
                        }).ToList(),
                        Characters = t.Character_Movies.Select(cm => new CharacterVM()
                        {
                            Id = cm.Character.Id,
                            Image = cm.Character.Image,
                            Name = cm.Character.Name,
                            Age = cm.Character.Age,
                            Weight = cm.Character.Weight,
                            History = cm.Character.History
                        }).ToList()
                    }).ToList();
                    //TODO: refactor query
                    if (filter.GenreId != 0)
                    {
                        _movies = _movies.Where(t => t.Genres.Any(n => n.Id == filter.GenreId)).ToList();
                    }
                    if (filter.Name != null)
                    {
                        _movies = _movies.Where(x => x.Title.ToLower().Contains(filter.Name)).ToList();
                    }


                    if (filter.Order != null)
                    {
                        if (filter.Order.ToLower() == "asc")
                        {
                            _movies = _movies.OrderBy(x => x.Title).ToList();
                        }
                        if (filter.Order.ToLower() == "desc")
                        {
                            _movies = _movies.OrderByDescending(x => x.Title).ToList();
                        }
                    }

                    var res = _movies.Select(t => new MovieGetVM
                    {
                        Image = t.Image,
                        Title = t.Title,
                        CreatedAt = t.CreatedAt
                    }).ToList();

                    return res;

                }
                else {
                    var _movies = _context.Movies.Select(t => new MovieGetVM
                    {
                        Image = t.Image,
                        Title = t.Title,
                        CreatedAt = t.CreatedAt,                        
                    }).ToList();

                    return _movies;
                }



            }
            catch (Exception)
            {
                throw;
            }
        }

        public MovieVM GetById(int id)
        {
            try
            {
                MovieVM _movies = _context.Movies.Where(n => n.Id == id)
                    .Select(t => new MovieVM
                    {
                        Id = t.Id,
                        Image = t.Image,
                        Title = t.Title,
                        CreatedAt = t.CreatedAt,
                        Qualification = t.Qualification,
                        Genres = t.Movie_Genres.Select(mg => new GenreVM()
                        {
                            Id = mg.Genre.Id,
                            Name = mg.Genre.Name,
                            Image = mg.Genre.Image
                        }).ToList(),
                        Characters = t.Character_Movies.Select(cm => new CharacterVM()
                        {
                            Id = cm.Character.Id,
                            Image = cm.Character.Image,
                            Name = cm.Character.Name,
                            Age = cm.Character.Age,
                            Weight = cm.Character.Weight,
                            History = cm.Character.History
                        }).ToList()
                    }).FirstOrDefault();
                return _movies;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public string Delete(int id)
        {
            Movie _movie = _context.Movies.Find(id);
            if (_movie == null)
            {
                return "Not Found";
            }
            _context.Movies.Remove(_movie);
            _context.SaveChangesAsync();
            return "Ok";
        }

        public string Update(int id, MovieVM _movieVM)
        {
            if (id != _movieVM.Id)
            {
                return "Bad Request";
            }
            MovieVM movie = new MovieVM()
            {
                Id = _movieVM.Id,
                Image = _movieVM.Image,
                Title = _movieVM.Title,
                CreatedAt = _movieVM.CreatedAt,
                Qualification = _movieVM.Qualification
            };

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
                return "Ok";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return "Not Found";
                }
                throw;
            }
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
