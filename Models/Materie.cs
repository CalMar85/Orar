using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orar.Models
{
    public class Materie
    {
        public int ID { get; set; }
        public string NumeMaterie { get; set; }
        public ICollection<Profesor> Profesori { get; set; }
    }
}
