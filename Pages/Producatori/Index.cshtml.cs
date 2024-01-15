using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazin_Alimentar.Data;
using Magazin_Alimentar.Models;
using System.Security.Policy;

namespace Magazin_Alimentar.Pages.Producatori
{
    public class IndexModel : PageModel
    {
        private readonly Magazin_Alimentar.Data.Magazin_AlimentarContext _context;

        public IndexModel(Magazin_Alimentar.Data.Magazin_AlimentarContext context)
        {
            _context = context;
        }

        public IList<Producator> Producator { get;set; } = default!;
        public ProducatorIndexData ProducatorData { get; set; }
        public int ProducatorID { get; set; }
        public int ProdusID { get; set; }
        public async Task OnGetAsync(int? id, int? produsID)
        {
            ProducatorData = new ProducatorIndexData();
            ProducatorData.Producatori = await _context.Producator.Include(i => i.Produse).OrderBy(i => i.ProducatorName).ToListAsync();
            if (id != null)
            {
                ProducatorID = id.Value;
               Producator producator = ProducatorData.Producatori
               .Where(i => i.ID == id.Value).Single();
                ProducatorData.Produse = producator.Produse;
            }
        }
    }
}
