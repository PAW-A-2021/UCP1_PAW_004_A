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
    public class PenyewaansController : Controller
    {
        private readonly RentKomikContext _context;

        public PenyewaansController(RentKomikContext context)
        {
            _context = context;
        }

        // GET: Penyewaans
        public async Task<IActionResult> Index()
        {
            var rentKomikContext = _context.Penyewaans.Include(p => p.IdAdminNavigation).Include(p => p.IdCustomerNavigation).Include(p => p.NoKomikNavigation);
            return View(await rentKomikContext.ToListAsync());
        }

        // GET: Penyewaans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyewaan = await _context.Penyewaans
                .Include(p => p.IdAdminNavigation)
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.NoKomikNavigation)
                .FirstOrDefaultAsync(m => m.IdSewa == id);
            if (penyewaan == null)
            {
                return NotFound();
            }

            return View(penyewaan);
        }

        // GET: Penyewaans/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin");
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer");
            ViewData["NoKomik"] = new SelectList(_context.Komiks, "NoKomik", "NoKomik");
            return View();
        }

        // POST: Penyewaans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSewa,Tanggal,IdCustomer,IdAdmin,NoKomik")] Penyewaan penyewaan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penyewaan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", penyewaan.IdAdmin);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", penyewaan.IdCustomer);
            ViewData["NoKomik"] = new SelectList(_context.Komiks, "NoKomik", "NoKomik", penyewaan.NoKomik);
            return View(penyewaan);
        }

        // GET: Penyewaans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyewaan = await _context.Penyewaans.FindAsync(id);
            if (penyewaan == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", penyewaan.IdAdmin);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", penyewaan.IdCustomer);
            ViewData["NoKomik"] = new SelectList(_context.Komiks, "NoKomik", "NoKomik", penyewaan.NoKomik);
            return View(penyewaan);
        }

        // POST: Penyewaans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSewa,Tanggal,IdCustomer,IdAdmin,NoKomik")] Penyewaan penyewaan)
        {
            if (id != penyewaan.IdSewa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penyewaan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenyewaanExists(penyewaan.IdSewa))
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
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", penyewaan.IdAdmin);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", penyewaan.IdCustomer);
            ViewData["NoKomik"] = new SelectList(_context.Komiks, "NoKomik", "NoKomik", penyewaan.NoKomik);
            return View(penyewaan);
        }

        // GET: Penyewaans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyewaan = await _context.Penyewaans
                .Include(p => p.IdAdminNavigation)
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.NoKomikNavigation)
                .FirstOrDefaultAsync(m => m.IdSewa == id);
            if (penyewaan == null)
            {
                return NotFound();
            }

            return View(penyewaan);
        }

        // POST: Penyewaans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penyewaan = await _context.Penyewaans.FindAsync(id);
            _context.Penyewaans.Remove(penyewaan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenyewaanExists(int id)
        {
            return _context.Penyewaans.Any(e => e.IdSewa == id);
        }
    }
}
