using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazin_Alimentar.Data;
using Magazin_Alimentar.Models;

namespace Magazin_Alimentar.Pages.Producatori
{
    public class DeleteModel : PageModel
    {
        private readonly Magazin_Alimentar.Data.Magazin_AlimentarContext _context;

        public DeleteModel(Magazin_Alimentar.Data.Magazin_AlimentarContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Producator Producator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producator == null)
            {
                return NotFound();
            }

            var producator = await _context.Producator.FirstOrDefaultAsync(m => m.ID == id);

            if (producator == null)
            {
                return NotFound();
            }
            else 
            {
                Producator = producator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Producator == null)
            {
                return NotFound();
            }
            var producator = await _context.Producator.FindAsync(id);

            if (producator != null)
            {
                Producator = producator;
                _context.Producator.Remove(Producator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
