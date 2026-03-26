using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using U2P3_PetsAPI.Models.Pets;

namespace U2P3_PetsAPI.Controllers
{
    public class VeterinariansController : Controller
    {
        private readonly PetsContext _context;

        public VeterinariansController(PetsContext context)
        {
            _context = context;
        }

        // GET: Veterinarians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veterinarians.ToListAsync());
        }

        // GET: Veterinarians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarian = await _context.Veterinarians
                .FirstOrDefaultAsync(m => m.VetId == id);
            if (veterinarian == null)
            {
                return NotFound();
            }

            return View(veterinarian);
        }

        // GET: Veterinarians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinarians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VetId,Name,Specialty")] Veterinarian veterinarian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinarian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinarian);
        }

        // GET: Veterinarians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarian = await _context.Veterinarians.FindAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }
            return View(veterinarian);
        }

        // POST: Veterinarians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VetId,Name,Specialty")] Veterinarian veterinarian)
        {
            if (id != veterinarian.VetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinarian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinarianExists(veterinarian.VetId))
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
            return View(veterinarian);
        }

        // GET: Veterinarians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarian = await _context.Veterinarians
                .FirstOrDefaultAsync(m => m.VetId == id);
            if (veterinarian == null)
            {
                return NotFound();
            }

            return View(veterinarian);
        }

        // POST: Veterinarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinarian = await _context.Veterinarians.FindAsync(id);
            if (veterinarian != null)
            {
                _context.Veterinarians.Remove(veterinarian);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinarianExists(int id)
        {
            return _context.Veterinarians.Any(e => e.VetId == id);
        }
    }
}
