using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.ViewModels
{
    public class CharacterVM
    {
        //TODO: duplicados con excepcion 63
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        //public virtual List<Cast> Casts { get; set; }
    }
}
