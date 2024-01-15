namespace Magazin_Alimentar.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string CategorieName { get; set; }
        public ICollection<ProdusCategorie>? ProdusCategorii { get; set; }
    }
}
