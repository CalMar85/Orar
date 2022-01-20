using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Orar.Data;
using Orar.Models;

namespace Orar.Pages.Materii
{
    public class IndexModel : PageModel
    {
        private readonly Orar.Data.OrarContext _context;

        public IndexModel(Orar.Data.OrarContext context)
        {
            _context = context;
        }

        public IList<Materie> Materie { get;set; }

        public async Task OnGetAsync()
        {
            Materie = await _context.Materie.ToListAsync();
        }
    }
}
