using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [Range(1, 5)]
        public byte Qualification { get; set; }
        public List<Character_Movie> Character_Movies { get; set; }
        public List<Movie_Genre> Movie_Genres { get; set; }

    }
}
