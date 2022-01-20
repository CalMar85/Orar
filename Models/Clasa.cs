using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orar.Models
{
    public class Clasa
    {
        public int ID { get; set; }
        public string NumeClasa { get; set; }
        public ICollection<ClasaProfesor> ClaseProfesor { get; set; }
    }
}
