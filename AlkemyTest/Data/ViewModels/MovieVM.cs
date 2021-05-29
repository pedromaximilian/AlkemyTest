using AlkemyTest.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte Qualification { get; set; }
        public List<Character_Movie> Character_Movies { get; set; }
        public List<Movie_Genre> Movie_Genres { get; set; }
    }
}
