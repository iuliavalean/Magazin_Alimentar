using System.Security.Policy;

namespace Magazin_Alimentar.Models
{
    public class ProducatorIndexData
    {
        public IEnumerable<Producator> Producatori { get; set; }
        public IEnumerable<Produs> Produse { get; set; }
    }
}
