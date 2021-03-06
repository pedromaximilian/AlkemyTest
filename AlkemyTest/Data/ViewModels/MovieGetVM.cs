using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.ViewModels
{
    public class MovieGetVM
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(100)]
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
