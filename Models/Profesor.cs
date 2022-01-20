using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orar.Models
{
    public class Profesor
    {
        public int ID { get; set; }

        [Display(Name = "Nume profesor")] 
        public string Nume { get; set; }
        [Display(Name = "Prenume profesor")] 
        public string Prenume { get; set; }

        [Display(Name = "Norma didactica (in ore)")] 
        public int Norma { get; set; }

        public int MaterieID { get; set; }
        public Materie Materie { get; set; }

        public ICollection<ClasaProfesor> ClaseProfesor { get; set; }


    }
}
