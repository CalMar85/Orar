using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orar.Models
{
    public class OrarCls
    {
        public int ID { get; set; }

        [Display(Name = "Ziua si Ora")]
        public string ZiOra { get; set; }

        public int ClasaID { get; set; }
        public Clasa Clasa { get; set; }
 
        public int MaterieID { get; set; }
        public Materie Materie { get; set; }

    }
}
