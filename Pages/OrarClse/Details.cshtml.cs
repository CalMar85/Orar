﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Orar.Data;
using Orar.Models;

namespace Orar.Pages.OrarClse
{
    public class DetailsModel : PageModel
    {
        private readonly Orar.Data.OrarContext _context;

        public DetailsModel(Orar.Data.OrarContext context)
        {
            _context = context;
        }

        public OrarCls OrarCls { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrarCls = await _context.OrarCls
                .Include(o => o.Materie).FirstOrDefaultAsync(m => m.ID == id);

            if (OrarCls == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
