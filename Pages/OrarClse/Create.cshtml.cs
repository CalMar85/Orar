using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orar.Data;
using Orar.Models;

namespace Orar.Pages.OrarClse
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
            ViewData["ClasaID"] = new SelectList(_context.Set<Clasa>(), "ID", "NumeClasa");

            return Page();
        }

        [BindProperty]
        public OrarCls OrarCls { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrarCls.Add(OrarCls);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
