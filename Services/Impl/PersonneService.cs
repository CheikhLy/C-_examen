namespace Cours.Services.Impl;

using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;



public class PersonneService : IPersonneService
{
    private readonly ApplicationDbContext _context;

    public Task<Models.Client> Create(Models.Personne personne)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Client> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Models.Personne>> GetPersonneAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Models.Client> Update(Models.Personne personne)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientService"/> class with the specified database context.
    /// </summary>
    // /// <param name="context">The <see cref="ApplicationDbContext"/> used to interact with the database.</param>
    //     public ClientService(ApplicationDbContext context)
    //     {
    //         this._context = context;
    //     }

    //     public async Task<Personne> Create(Personne personne )
    //     {

    //         _context.client.Add(client);

    //         await _context.SaveChangesAsync();

    //         return client;
    //     }

    //     public Task<Client> Delete(int id)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public async Task<IEnumerable<Client>> GetClientsAsync()
    //     {
    //         // Your implementation to fetch clients from your data source
    //         return await _context.client.ToListAsync();
    //     }

    //     public Task<Client> Update(Client client)
    //     {
    //         throw new NotImplementedException();
    //     }
}