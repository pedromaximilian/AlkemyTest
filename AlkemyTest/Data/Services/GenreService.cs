using AlkemyTest.Data.Models;
using AlkemyTest.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Services
{
    public class GenreService
    {
        private readonly DataContext _context;

        public GenreService(DataContext context)
        {
            _context = context;
        }
        public int  Add(GenreVM genre)
        {
            if (!_context.Genres.Any(t => t.Name.ToLower().Equals(genre.Name.ToLower())))
            {
                try
                {
                    Genre _genre = new Genre
                    {
                        Image = genre.Image,
                        Name = genre.Name
                    };

                    _context.Genres.Add(_genre);
                    _context.SaveChanges();
                    return _genre.Id;
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

        public List<GenreVM> GetAll()
        {
            try
            {
                var _genres = _context.Genres.Select(t => new GenreVM
                {
                    Id = t.Id,
                    Image = t.Image,
                    Name = t.Name

                }).ToList();

                return _genres;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public GenreVM GetById(int id)
        {
            try
            {
                var res = _context.Genres.Where(t => t.Id == id)
                    .Select(t => new GenreVM
                    {
                        Id = t.Id,
                        Image = t.Image,
                        Name = t.Name
                    }).FirstOrDefault();
                return res;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public string Update(int id, GenreVM genre)
        {
            if (id != genre.Id)
            {
                throw new("Bad Request");
            }

            Genre _genre = new Genre
            {
                Id = genre.Id,
                Image = genre.Image,
                Name = genre.Name
            };

            _context.Entry(_genre).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return "Ok";
            }
            catch (DbUpdateConcurrencyException)
            { 
                throw;
            }


        }


        public string Delete(int id)
        {
            Genre genre = _context.Genres.Find(id);
            if (genre == null)
            {
                return "Not Found";
            }
            _context.Genres.Remove(genre);
            _context.SaveChangesAsync();
            return "Ok";
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }


    }
}
