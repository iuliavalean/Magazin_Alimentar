namespace Magazin_Alimentar.Models
{
    public class Producator
    {
        public int ID { get; set; }
        public string ProducatorName { get; set; }
        public ICollection<Produs>? Produse { get; set; }
    }
}
