using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Services.Impl;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;

/// <summary>
/// Initializes a new instance of the <see cref="ClientService"/> class with the specified database context.
/// </summary>
/// <param name="context">The <see cref="ApplicationDbContext"/> used to interact with the database.</param>
    public ClientService(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<Client> Create(Client client)
    {
        
        _context.client.Add(client);
        
        await _context.SaveChangesAsync();

        return client;
    }

    public Task<Commande> CreateCommande(int clientId, int produitId, int quantite)
    {
        throw new NotImplementedException();
    }

    public Task<Client> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        // Your implementation to fetch clients from your data source
        return await _context.client.ToListAsync();
    }

    public Task<Client> Update(Client client)
    {
        throw new NotImplementedException();
    }
}