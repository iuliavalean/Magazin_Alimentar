using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Magazin_Alimentar.Models
{
    public class Produs
    {
        public int ID { get; set; }
        [Display(Name = "Produse")]
        public string? Nume { get; set; }
        public int? ProducatorID { get; set; }
        public Producator? Producator { get; set; }
        public decimal Cantitate { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataExpirare { get; set; }
        public ICollection<ProdusCategorie>? ProdusCategorii { get; set; }

    }
}
