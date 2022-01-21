using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orar.Models
{
    public class ProfesorDetaliu
    {
        public IEnumerable<Profesor> Profesori { get; set; }
        public IEnumerable<Clasa> Clase { get; set; }
        public IEnumerable<ClasaProfesor> ClaseProfesor { get; set; }
    }
}
