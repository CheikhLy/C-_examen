using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cours.Models;

namespace ges_commande.Controllers
{
    public class PaiementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaiementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paiement
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.paiement.Include(p => p.commande);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Paiement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paiements = await _context.paiement
                .Include(p => p.commande)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paiements == null)
            {
                return NotFound();
            }

            return View(paiements);
        }

        // GET: Paiement/Create
        // GET: Paiement/Create
            public IActionResult Create(int? commandeId)
            {
                if (commandeId == null || !_context.commande.Any(c => c.Id == commandeId))
                {
                    return NotFound();
                }

                // Passer l'ID de la commande à la vue
                ViewData["commandeId"] = commandeId;
                return View();
            }


        // POST: Paiement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Paiement/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("commandeId,reduction,typePaiement,Id,CreateAt,UpdateAt")] Paiements paiements)
{
    if (ModelState.IsValid)
    {
        _context.Add(paiements);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Renvoyer l'ID de la commande si la validation échoue
    ViewData["commandeId"] = paiements.commandeId;
    return View(paiements);
}
        // GET: Paiement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paiements = await _context.paiement.FindAsync(id);
            if (paiements == null)
            {
                return NotFound();
            }
            ViewData["commandeId"] = new SelectList(_context.commande, "Id", "Id", paiements.commandeId);
            return View(paiements);
        }

        // POST: Paiement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("commandeId,reduction,Id,CreateAt,UpdateAt")] Paiements paiements)
        {
            if (id != paiements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paiements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaiementsExists(paiements.Id))
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
            ViewData["commandeId"] = new SelectList(_context.commande, "Id", "Id", paiements.commandeId);
            return View(paiements);
        }

        // GET: Paiement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paiements = await _context.paiement
                .Include(p => p.commande)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paiements == null)
            {
                return NotFound();
            }

            return View(paiements);
        }

        // POST: Paiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paiements = await _context.paiement.FindAsync(id);
            if (paiements != null)
            {
                _context.paiement.Remove(paiements);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiementsExists(int id)
        {
            return _context.paiement.Any(e => e.Id == id);
        }
    }
}
