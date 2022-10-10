using Geoprofs.Data;
using Geoprofs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Geoprofs.Controllers
{
    public class HomeController : Controller
    {
        private readonly GeoprofsContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult VerlofAanvraag()
        {
            return View();
        }

        public async Task<IActionResult> MijnVerlof(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerkers
                .Include(s => s.Afwezigheids)
                    .ThenInclude(e => e.CategorieID)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        public IActionResult TeamAanvragen()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
