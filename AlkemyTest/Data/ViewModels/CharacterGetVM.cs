using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.ViewModels
{
    public class CharacterGetVM
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
