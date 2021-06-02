using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual List<Movie_Genre> Movie_Genres { get; set; }
    }
    
}
