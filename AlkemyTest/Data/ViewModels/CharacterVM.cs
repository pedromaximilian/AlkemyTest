using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.ViewModels
{
    public class CharacterVM
    { 
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public float? Weight { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string History { get; set; }


        public List<MovieVM> Movies { get; set; }
    }
}
