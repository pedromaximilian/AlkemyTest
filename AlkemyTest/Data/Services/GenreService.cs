using AlkemyTest.Data.Models;
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

        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
        
            return await _context.Genres.ToListAsync();

        }


    }
}
