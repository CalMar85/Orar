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
    public class CreateModel : PageModel
    {
        private readonly Orar.Data.OrarContext _context;

        public CreateModel(Orar.Data.OrarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MaterieID"] = new SelectList(_context.Set<Materie>(), "ID", "NumeMaterie");

            return Page();
        }

        [BindProperty]
        public Profesor Profesor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Profesor.Add(Profesor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
