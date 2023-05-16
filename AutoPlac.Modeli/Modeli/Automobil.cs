using System.ComponentModel.DataAnnotations;

namespace AutoPlac.Modeli.Modeli
{
    public class Automobil
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Marka { get; set; }
        public int Godiste { get; set; }
        public int Cena { get; set; }
        public DateTime DatumIzdanja { get; set; }
    }
}