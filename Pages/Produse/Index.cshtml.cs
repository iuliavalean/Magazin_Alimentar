using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Magazin_Alimentar.Data;
using Magazin_Alimentar.Models;
using System.Net;

namespace Magazin_Alimentar.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Magazin_Alimentar.Data.Magazin_AlimentarContext _context;

        public IndexModel(Magazin_Alimentar.Data.Magazin_AlimentarContext context)
        {
            _context = context;
        }
        public IList<Produs> Produs { get; set; } = default!;
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategorieID { get; set; }
        public string NumeSort { get; set; }
        public string ProducatorSort { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder)
        {
            if (_context.Produs != null)
            {
                ProdusD = new ProdusData();

                NumeSort = string.IsNullOrEmpty(sortOrder) ? " nume_desc " : "";
                ProducatorSort = sortOrder == "producator" ? "producator_desc" : "producator";
                Produs = await _context.Produs
                .Include(b => b.Producator)
                .Include(b => b.ProdusCategorii)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();


                if (id != null)
                {
                    ProdusID = id.Value;
                    Produs produs = ProdusD.Produse
                   .Where(i => i.ID == id.Value).Single();
                    ProdusD.Categorii = produs.ProdusCategorii.Select(s => s.Categorie);

                    switch (sortOrder)
                    {
                        case " nume_desc ":
                            ProdusD.Produse = ProdusD.Produse.OrderByDescending(s => s.Nume);
                            break;
                        case " producator_desc ":
                            ProdusD.Produse = ProdusD.Produse.OrderByDescending(s => s.Producator);
                            break;
                        case "producator":
                            ProdusD.Produse = ProdusD.Produse.OrderBy(s => s.Producator);
                            break;
                        default:
                            ProdusD.Produse = ProdusD.Produse.OrderBy(s => s.Nume);
                            break;

                    }
                }
            }
        }

    }
}
