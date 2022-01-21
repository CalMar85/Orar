using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Orar.Data;
using Orar.Models;

namespace Orar.Pages.Profesori
{
    public class IndexModel : PageModel
    {
        private readonly Orar.Data.OrarContext _context;

        public IndexModel(Orar.Data.OrarContext context)
        {
            _context = context;
        }


        public IList<Profesor> Profesor { get;set; }
        public ProfesorDetaliu ProfesorD { get; set; }
        public int ProfesorID { get; set; }
        public int ClasaID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProfesorD = new ProfesorDetaliu();

            ProfesorD.Profesori = await _context.Profesor
                .Include(b => b.Materie)
            .Include(b => b.ClaseProfesor)
            .ThenInclude(b => b.Clasa)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                ProfesorID = id.Value;
                Profesor profesor = ProfesorD.Profesori
                .Where(i => i.ID == id.Value).Single();
                ProfesorD.Clase = profesor.ClaseProfesor.Select(s => s.Clasa);
            }
        }
    }
}
