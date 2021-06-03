using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public float? Weight { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string History { get; set; }
        public List<Character_Movie> Character_Movies { get; set; }
    }
}
