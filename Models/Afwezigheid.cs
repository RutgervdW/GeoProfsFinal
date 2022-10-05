using System;

namespace Geoprofs.Models
{
    public class Afwezigheid
    {
        public int ID { get; set; }
        public int MedewerkerID { get; set; }
        public int AfwezigheidCategorieID { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; } 
        public string Redenering { get; set; }
        public DateTime DatumAanvraag { get; set; } 
        public string Status { get; set; }
    }
}
