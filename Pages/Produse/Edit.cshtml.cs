﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Magazin_Alimentar.Data;
using Magazin_Alimentar.Models;

namespace Magazin_Alimentar.Pages.Produse
{
    public class EditModel : PageModel
    {
        private readonly Magazin_Alimentar.Data.Magazin_AlimentarContext _context;

        public EditModel(Magazin_Alimentar.Data.Magazin_AlimentarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            var produs =  await _context.Produs.FirstOrDefaultAsync(m => m.ID == id);
            if (produs == null)
            {
                return NotFound();
            }
            Produs = produs;
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "ProducatorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(Produs.ID))
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

        private bool ProdusExists(int id)
        {
          return (_context.Produs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
