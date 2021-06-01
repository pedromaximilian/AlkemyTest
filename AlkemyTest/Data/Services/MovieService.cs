using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Services
{
    public class MovieService
    {
        private readonly DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }


        public void Add(MovieVM movieVM)
        {
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

        public  List<MovieVM> GetAll() {
            try
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

                return _movies;
            }
            catch (Exception)
            {

                throw;
            }

            
        }



    }
}
