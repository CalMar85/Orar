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

        public async Task OnGetAsync()
        {
            Profesor = await _context.Profesor
                .Include(b => b.Materie)
                .ToListAsync();
        }
    }
}
