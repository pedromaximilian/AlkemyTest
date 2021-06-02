using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Models
{
    public class Movie_Genre
    {
      
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }


    }
}
