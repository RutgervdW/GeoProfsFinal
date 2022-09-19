using Geoprofs.Models;
using Microsoft.EntityFrameworkCore;

namespace Geoprofs.Data
{
    public class GeoprofsContext : DbContext
    {
        public GeoprofsContext(DbContextOptions<GeoprofsContext> options) : base(options)
        {

        }
        public DbSet<Afwezigheid> Afwezigheids { get; set; }
        public DbSet<AfwezigheidCategorie> AfwezigheidCategories { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Positie> Posities { get; set; }
    }


}
