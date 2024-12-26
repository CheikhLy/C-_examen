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
    public class CommandeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommandeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commande
        public async Task<IActionResult> Index()
        {
            // var applicationDbContext = _context.commande.Include(c => c.Client).Include(c => c.livreur);
            // return View(await applicationDbContext.ToListAsync());
            var commande = await _context.commande.ToListAsync();
            return View(commande);
        }

        // GET: Commande/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.commande
                .Include(c => c.Client)
                .Include(c => c.livreur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // GET: Commande/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.client, "Id", "Id");
            ViewData["LivreurId"] = new SelectList(_context.livreur, "Id", "Id");
            return View();
        }

        // POST: Commande/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateCommande,PrixTotal,ClientId,LivreurId,paiementId,Id,CreateAt,UpdateAt")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.client, "Id", "Id", commande.ClientId);
            ViewData["LivreurId"] = new SelectList(_context.livreur, "Id", "Id", commande.LivreurId);
            return View(commande);
        }

        // GET: Commande/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.commande.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.client, "Id", "Id", commande.ClientId);
            ViewData["LivreurId"] = new SelectList(_context.livreur, "Id", "Id", commande.LivreurId);
            return View(commande);
        }

        // POST: Commande/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DateCommande,PrixTotal,ClientId,LivreurId,paiementId,Id,CreateAt,UpdateAt")] Commande commande)
        {
            if (id != commande.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandeExists(commande.Id))
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
            ViewData["ClientId"] = new SelectList(_context.client, "Id", "Id", commande.ClientId);
            ViewData["LivreurId"] = new SelectList(_context.livreur, "Id", "Id", commande.LivreurId);
            return View(commande);
        }

        // GET: Commande/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.commande
                .Include(c => c.Client)
                .Include(c => c.livreur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // POST: Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commande = await _context.commande.FindAsync(id);
            if (commande != null)
            {
                _context.commande.Remove(commande);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return _context.commande.Any(e => e.Id == id);
        }
[HttpPost]
public async Task<IActionResult> ValiderCommande(int id)
{
    var commande = await _context.commande.FirstOrDefaultAsync(c => c.Id == id);
    if (commande == null)
    {
        TempData["Error"] = "Commande introuvable.";
        return RedirectToAction("ListeCommandes");
    }

    if (commande.etat != Cours.Enum.Etat.enCours)
    {
        TempData["Error"] = "Cette commande ne peut pas être validée car elle n'est pas en cours.";
        return RedirectToAction("ListeCommandes");
    }

    commande.etat = Cours.Enum.Etat.actif;
    await _context.SaveChangesAsync();

    TempData["Message"] = "Commande validée avec succès.";
    return RedirectToAction("ListeCommandes");
}

[HttpPost]
public async Task<IActionResult> RefuserCommande(int id)
{
    var commande = await _context.commande.FirstOrDefaultAsync(c => c.Id == id);
    if (commande == null)
    {
        TempData["Error"] = "Commande introuvable.";
        return RedirectToAction("ListeCommandes");
    }

    if (commande.etat != Cours.Enum.Etat.enCours)
    {
        TempData["Error"] = "Cette commande ne peut pas être refusée car elle n'est pas en cours.";
        return RedirectToAction("ListeCommandes");
    }

    commande.etat = Cours.Enum.Etat.inactif;
    await _context.SaveChangesAsync();

    TempData["Message"] = "Commande refusée avec succès.";
    return RedirectToAction("ListeCommandes");
}

    }
}
