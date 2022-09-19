using System;
using System.Collections.Generic;

namespace Geoprofs.Models
{
    public class Medewerker
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int BSN { get; set; }
        public int PositieID { get; set; }
        public int? SupervisorID { get; set; }
        public DateTime DatumInDienst { get; set; }
        public string Opmerkingen { get; set; } = "";
        public int VakantieDagenPerJaar { get; set; } = 30;
        public int VakantieDagenGenomen { get; set; } = 0;
        public int PersoonlijkDagenGenomen { get; set; } = 0;
        public int ZiekDagenGenomen { get; set; } = 0;
        public int WeekUren { get; set; } = 40;
        public int WerkDagen { get; set; } = 5;

        public ICollection<Afwezigheid> Afwezigheden { get; set; }
    }
}
