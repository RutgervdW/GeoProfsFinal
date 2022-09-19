using Geoprofs.Data;
using Microsoft.EntityFrameworkCore;
using Geoprofs.Models;
using System;
using System.Linq;

namespace Geoprofs.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeoprofsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Afwezigheids.Any())
            {
                return;
            }
            var posities = new Positie[]
            {
                new Positie{Naam="Software Developer"},
                new Positie{Naam="Manager"},
                new Positie{Naam="Receptionist"},
                new Positie{Naam="CEO"}
            };
            foreach (Positie positie in posities)
            {
                context.Posities.Add(positie);
            }
            context.SaveChanges();

            var afwezigheidCategories = new AfwezigheidCategorie[]
            {
                new AfwezigheidCategorie{Naam="Ziekte"},
                new AfwezigheidCategorie{Naam="Ongeoorloofd"},
                new AfwezigheidCategorie{Naam="Evenement"}
            };
            foreach (AfwezigheidCategorie afwezigheidCategorie in afwezigheidCategories)
            {
                context.AfwezigheidCategories.Add(afwezigheidCategorie);
            }
            context.SaveChanges();

            var medewerkers = new Medewerker[]
            {
                new Medewerker{Voornaam="Henk", Achternaam="Janssen", BSN=123123123, PositieID=1, SupervisorID=2, DatumInDienst=new DateTime(2020, 5, 1), Opmerkingen="", VakantieDagenPerJaar=30, VakantieDagenGenomen=0, PersoonlijkDagenGenomen=0, ZiekDagenGenomen=0, WeekUren=40, WerkDagen=5},
                new Medewerker{Voornaam="Lanette", Achternaam="Birgussen", BSN=321321321, PositieID=2, DatumInDienst=new DateTime(2021, 4, 21)},
                new Medewerker{Voornaam="Lunk", Achternaam="Mooihooi", BSN=555555555, PositieID=3, SupervisorID=2, DatumInDienst=new DateTime(2019, 3, 15)}
            };
            foreach (Medewerker medewerker in medewerkers)
            {
                context.Add(medewerker);
            }
            context.SaveChanges();

            var afwezigheids = new Afwezigheid[]
            {
                new Afwezigheid{MedewerkerID=1, Begindatum=new DateTime(2022, 9, 19, 9, 0, 0), Einddatum=new DateTime(2022, 9, 19, 17, 0, 0), CategorieID=1, Redenering="buikpijn :(", DatumAanvraag=new DateTime(2022, 9, 18), Status="Approved"}
            };
        }   
    }
}
