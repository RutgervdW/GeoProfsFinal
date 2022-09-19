using Geoprofs.Data;
using Microsoft.EntityFrameworkCore;
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
            
        }
    }
}
