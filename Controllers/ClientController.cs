using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cours.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using ges_commande.Models;
using Cours.Enum;

namespace ges_commande.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }
[HttpPost]
// public async Task<ActionResult> Connexion(string login, string password)
// {
//     // Vérifier les informations de connexion
//     var user = await _context.users.FirstOrDefaultAsync(c => c.login == login && c.password == password);

//     if (user != null)
//     {
//         // Stocker le nom de l'utilisateur connecté dans la session
//         HttpContext.Session.SetString("NomUtilisateur", user.login);

//         // Rediriger vers la page d'accueil
//         return RedirectToAction("Accueil");
//     }
//     else
//     {
//         // Les informations de connexion sont incorrectes, afficher un message d'erreur
//         ModelState.AddModelError("", "Informations de connexion incorrectes");
//         return View();
//     }
// }
     
        
        // GET: Client 
        public async Task<IActionResult> Index()
         { // Exemple de stockage de données dans la session 
        //  HttpContext.Session.SetString("NomUtilisateur", "JohnDoe");
          return View(await _context.client.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Solde,Adresse,Id,CreateAt,UpdateAt")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        //         public async Task<IActionResult> CreateCommande([Bind("produit,quantite")] Commande commande)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(commande);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(commande);
        // }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Solde,Adresse,Id,CreateAt,UpdateAt")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.client.FindAsync(id);
            if (client != null)
            {
                _context.client.Remove(client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.client.Any(e => e.Id == id);
        }
        
          [HttpGet]
        public IActionResult CreerCommande()
        {
            ViewData["Title"] = "Créer une Demande";
            return View("CreerCommande");
        }

        [HttpPost]
public IActionResult CreerCommande(int ProduitId, int Quantite)
{
    var errors = new List<string>();
    string message = string.Empty;
    

    // Récupération du produit
    var produit = _context.produit.FirstOrDefault(p => p.Id == ProduitId);

    // Validation des entrées
    if (produit == null)
        errors.Add("Produit introuvable.");
    if (Quantite <= 0)
        errors.Add("La quantité doit être supérieure à 0.");
    if (produit != null && produit.Quantite < Quantite)
        errors.Add("Stock insuffisant pour le produit.");

    // Si des erreurs sont détectées, retourner à la vue avec les erreurs
    if (errors.Any())
    {
        ViewData["Errors"] = errors;
        return View();
    }

    // Mise à jour des données du produit
    produit.Quantite -= Quantite;

    // Création de la nouvelle commande
    var nouvelleCommande = new Commande
    { 
        DateCommande = DateTime.Now,
        etat = Cours.Enum.Etat.enCours,
        PrixTotal = produit.Prix * Quantite,
        detailsCommandes = new List<DetailsCommande>
        {
            new DetailsCommande
            {
                produitID = ProduitId,
                qteCommande = Quantite,
                prix = produit.Prix * Quantite,
                
              
                
            }
        }
    };

    // Sauvegarde dans la base de données
    try
    {
        _context.commande.Add(nouvelleCommande);
        _context.SaveChanges();
        message = "Commande créée avec succès.";
    }
    catch (Exception ex)
    {
        errors.Add("Une erreur est survenue lors de la création de la commande : " + ex.Message);
        ViewData["Errors"] = errors;
        return View();
    }

    // Retourner un message de succès
    ViewData["Message"] = message;
    return View();
    }
    [HttpGet]
    [Route("Client/ListeCommandes")]
            public async Task<IActionResult> ListeCommandes()
        {
            var commandes = await _context.commande.Include(c => c.Client).ToListAsync();

            return View(commandes);
        }
    [HttpPost]
        [Route("Client/FairePaiement")]
    public async Task<IActionResult> FairePaiement(int commandeID) {
        var commande = await _context.commande.FirstOrDefaultAsync(c => c.Id == commandeID);
        if (commande != null) {
          string message = "Paiement effectué avec successe.";
        }
        return RedirectToAction("ListeCommandes");
    }



    } 
          
    
}
