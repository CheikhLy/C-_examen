using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Services.Impl;

public class CommandeService : ICommandeService
{
    private readonly ApplicationDbContext _context;

/// <summary>
/// Initializes a new instance of the <see cref="ClientService"/> class with the specified database context.
/// </summary>
/// <param name="context">The <see cref="ApplicationDbContext"/> used to interact with the database.</param>
   public CommandeService(ApplicationDbContext context)
{
    this._context = context;
}

    public async Task<Models.Commande> Create(Models.Commande commande)
    {
        _context.commande.Add(commande);
        await _context.SaveChangesAsync();
        return commande;
    }

    public Task<Models.Commande> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Models.Commande>> GetCommandesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Models.Commande> Update(Models.Commande client)
    {
        throw new NotImplementedException();
    }
}