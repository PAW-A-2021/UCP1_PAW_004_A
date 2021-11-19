using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_004_A.Models;

namespace UCP1_PAW_004_A.Controllers
{
    public class KomiksController : Controller
    {
        private readonly RentKomikContext _context;

        public KomiksController(RentKomikContext context)
        {
            _context = context;
        }

        // GET: Komiks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Komiks.ToListAsync());
        }

        // GET: Komiks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komik = await _context.Komiks
                .FirstOrDefaultAsync(m => m.NoKomik == id);
            if (komik == null)
            {
                return NotFound();
            }

            return View(komik);
        }

        // GET: Komiks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Komiks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoKomik,NamaKomik,Pengarang,Penerbit")] Komik komik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komik);
        }

        // GET: Komiks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komik = await _context.Komiks.FindAsync(id);
            if (komik == null)
            {
                return NotFound();
            }
            return View(komik);
        }

        // POST: Komiks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoKomik,NamaKomik,Pengarang,Penerbit")] Komik komik)
        {
            if (id != komik.NoKomik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomikExists(komik.NoKomik))
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
            return View(komik);
        }

        // GET: Komiks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komik = await _context.Komiks
                .FirstOrDefaultAsync(m => m.NoKomik == id);
            if (komik == null)
            {
                return NotFound();
            }

            return View(komik);
        }

        // POST: Komiks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komik = await _context.Komiks.FindAsync(id);
            _context.Komiks.Remove(komik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomikExists(int id)
        {
            return _context.Komiks.Any(e => e.NoKomik == id);
        }
    }
}
