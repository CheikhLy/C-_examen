using Cours.Models;
using Cours.Models;
using ges_commande.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Services.Impl;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

/// <summary>
/// Initializes a new instance of the <see cref="ClientService"/> class with the specified database context.
/// </summary>
/// <param name="context">The <see cref="ApplicationDbContext"/> used to interact with the database.</param>
    public UserService(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<User> Create(User user)
    {
        
        _context.users.Add(user);
        
        await _context.SaveChangesAsync();

        return user;
    }

    public Task<Client> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        // Your implementation to fetch clients from your data source
        return await _context.users.ToListAsync();
    }

/// <summary>
/// Updates the specified user in the database.
/// </summary>
/// <param name="user">The user to update.</param>
/// <returns>The updated user.</returns>
    public Task<User> Update(User user)
    {
        throw new NotImplementedException();
    }

    Task<Client> IUserService.Create(User user)
    {
        throw new NotImplementedException();
    }

    Task<Client> IUserService.Update(User user)
    {
        throw new NotImplementedException();
    }
}