using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Models
{
    public class Character
    {
        //TODO: duplicados con excepcion 63
        public int Id { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        //public virtual List<Cast> Casts { get; set; }
    }
}
