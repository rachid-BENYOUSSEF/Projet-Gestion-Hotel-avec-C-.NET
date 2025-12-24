using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestionhotel.Models;
using Microsoft.AspNetCore.Authorization;

namespace gestionhotel.Controllers
{
    [Authorize(Roles = "admin")]
    public class FidelitesController : Controller
    {
        private readonly HotelContext _context;

        public FidelitesController(HotelContext context)
        {
            _context = context;
        }

        // GET: Fidelites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fidelites.ToListAsync());
        }

        // GET: Fidelites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fidelite = await _context.Fidelites
                .FirstOrDefaultAsync(m => m.FideliteId == id);
            if (fidelite == null)
            {
                return NotFound();
            }

            return View(fidelite);
        }

        // GET: Fidelites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fidelites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FideliteId,NiveauFidelite,OffreFidelite,PointsFidelite")] Fidelite fidelite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fidelite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fidelite);
        }

        // GET: Fidelites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fidelite = await _context.Fidelites.FindAsync(id);
            if (fidelite == null)
            {
                return NotFound();
            }
            return View(fidelite);
        }

        // POST: Fidelites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FideliteId,NiveauFidelite,OffreFidelite,PointsFidelite")] Fidelite fidelite)
        {
            if (id != fidelite.FideliteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fidelite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FideliteExists(fidelite.FideliteId))
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
            return View(fidelite);
        }

        // GET: Fidelites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fidelite = await _context.Fidelites
                .FirstOrDefaultAsync(m => m.FideliteId == id);
            if (fidelite == null)
            {
                return NotFound();
            }

            return View(fidelite);
        }

        // POST: Fidelites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fidelite = await _context.Fidelites.FindAsync(id);
            if (fidelite != null)
            {
                _context.Fidelites.Remove(fidelite);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FideliteExists(int id)
        {
            return _context.Fidelites.Any(e => e.FideliteId == id);
        }
    }
}
