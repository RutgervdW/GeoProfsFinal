using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geoprofs.Data;
using Geoprofs.Models;

namespace Geoprofs.Controllers
{
    public class AfwezigheidsController : Controller
    {
        private readonly GeoprofsContext _context;

        public AfwezigheidsController(GeoprofsContext context)
        {
            _context = context;
        }

        // GET: Afwezigheids
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afwezigheids.ToListAsync());
        }

        // GET: Afwezigheids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afwezigheid = await _context.Afwezigheids
                .FirstOrDefaultAsync(m => m.ID == id);
            if (afwezigheid == null)
            {
                return NotFound();
            }

            return View(afwezigheid);
        }

        // GET: Afwezigheids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Afwezigheids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MedewerkerID,CategorieID,Begindatum,Einddatum,Redenering,DatumAanvraag,Status")] Afwezigheid afwezigheid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afwezigheid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(afwezigheid);
        }

        // GET: Afwezigheids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afwezigheid = await _context.Afwezigheids.FindAsync(id);
            if (afwezigheid == null)
            {
                return NotFound();
            }
            return View(afwezigheid);
        }

        // POST: Afwezigheids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MedewerkerID,CategorieID,Begindatum,Einddatum,Redenering,DatumAanvraag,Status")] Afwezigheid afwezigheid)
        {
            if (id != afwezigheid.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afwezigheid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfwezigheidExists(afwezigheid.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(afwezigheid);
        }

        // GET: Afwezigheids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afwezigheid = await _context.Afwezigheids
                .FirstOrDefaultAsync(m => m.ID == id);
            if (afwezigheid == null)
            {
                return NotFound();
            }

            return View(afwezigheid);
        }

        // POST: Afwezigheids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afwezigheid = await _context.Afwezigheids.FindAsync(id);
            _context.Afwezigheids.Remove(afwezigheid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfwezigheidExists(int id)
        {
            return _context.Afwezigheids.Any(e => e.ID == id);
        }
    }
}
