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

namespace Orar.Pages.OrarClse
{
    public class EditModel : ClaseProfesorPageModel
    {
        private readonly Orar.Data.OrarContext _context;

        public EditModel(Orar.Data.OrarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrarCls OrarCls { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrarCls = await _context.OrarCls
                .Include(o => o.Materie)

                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (OrarCls == null)
            {
                return NotFound();
            }
            ViewData["MaterieID"] = new SelectList(_context.Set<Materie>(), "ID", "NumeMaterie");
            ViewData["ClasaID"] = new SelectList(_context.Set<Clasa>(), "ID", "NumeClasa");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrarCls).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrarClsExists(OrarCls.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrarClsExists(int id)
        {
            return _context.OrarCls.Any(e => e.ID == id);
        }
    }
}
