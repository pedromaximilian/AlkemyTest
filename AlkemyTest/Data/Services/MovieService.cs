using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
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

        public List<MovieVM> GetAll() {

            return _context.Movies.Select(t => new MovieVM
            {
                Id = t.Id,
                Image = t.Image,
                Title = t.Title,
                CreatedAt = t.CreatedAt,
                Qualification = t.Qualification
            }).ToList();
        }



    }
}
