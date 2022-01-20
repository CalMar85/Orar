using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orar.Models
{
    public class ClasaProfesor
    {
        public int ID { get; set; }
        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }
        public int ClasaID { get; set; }
        public Clasa Clasa { get; set; }
    }
}
