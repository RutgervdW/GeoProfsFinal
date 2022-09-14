using System;

namespace Geoprofs.Models
{
    public class Medewerker
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int BSN { get; set; }
        public int PositieID { get; set; }
        public int SupervisorID { get; set; }
        public DateTime DatumInDienst { get; set; }
        public string Opmerkingen { get; set; }
        public int VakantieDagenPerJaar { get; set; }
        public int PersoonlijkDagenGenomen { get; set; }
        public int ZiekDagenGenomen { get; set; }
        public int WeekUren { get; set; }
        public int WerkDagen { get; set; }
    }
}
