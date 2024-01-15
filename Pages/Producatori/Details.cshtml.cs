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
    public class DetailsModel : PageModel
    {
        private readonly Magazin_Alimentar.Data.Magazin_AlimentarContext _context;

        public DetailsModel(Magazin_Alimentar.Data.Magazin_AlimentarContext context)
        {
            _context = context;
        }

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
    }
}
