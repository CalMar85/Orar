using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orar.Data;
using Orar.Models;

namespace Orar.Pages.Profesori
{
    public class CreateModel : ClaseProfesorPageModel
    {
        private readonly Orar.Data.OrarContext _context;

        public CreateModel(Orar.Data.OrarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MaterieID"] = new SelectList(_context.Set<Materie>(), "ID", "NumeMaterie");

            var profesor = new Profesor();
            profesor.ClaseProfesor = new List<ClasaProfesor>();
            PopulateClasaAsignata(_context, profesor);
            return Page();
        }

        [BindProperty]
        public Profesor Profesor { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedClase)
        {
            var newProfesor = new Profesor();
            if (selectedClase != null)
            {
                newProfesor.ClaseProfesor = new List<ClasaProfesor>();
                foreach (var cls in selectedClase)
                {
                    var clsToAdd = new ClasaProfesor
                    {
                        ClasaID = int.Parse(cls)
                    };
                    newProfesor.ClaseProfesor.Add(clsToAdd);
                }
            }
            if (await TryUpdateModelAsync<Profesor>(
            newProfesor, "Profesor",
                i => i.Nume, i => i.Prenume,
                i => i.Norma, i => i.MaterieID))
            {
                _context.Profesor.Add(newProfesor);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateClasaAsignata(_context, newProfesor);
            return Page();
        }
    }
}
