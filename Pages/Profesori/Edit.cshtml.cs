using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orar.Data;
using Orar.Models;

namespace Orar.Pages.Profesori
{
    public class EditModel : ClaseProfesorPageModel
    {
        private readonly Orar.Data.OrarContext _context;

        public EditModel(Orar.Data.OrarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesor Profesor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            Profesor = await _context.Profesor
                .Include(b => b.Materie)
                .Include(b => b.ClaseProfesor).ThenInclude(b => b.Clasa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Profesor == null)
            {
                return NotFound();
            }
            PopulateClasaAsignata(_context, Profesor);

            ViewData["MaterieID"] = new SelectList(_context.Set<Materie>(), "ID", "NumeMaterie");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedClase)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profesorToUpdate = await _context.Profesor
                .Include(i => i.Materie)
                .Include(i => i.ClaseProfesor)
                .ThenInclude(i => i.Clasa)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (profesorToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Profesor>(profesorToUpdate, "Profesor",
                 i => i.Nume, i => i.Prenume,
                 i => i.Norma, i => i.Materie))
            {
                UpdateClaseProfesor(_context, selectedClase, profesorToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateClaseProfesor(_context, selectedClase, profesorToUpdate);
            PopulateClasaAsignata(_context, profesorToUpdate);
            return Page();
        }
    }

}

