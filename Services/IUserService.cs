using Cours.Models;
using ges_commande.Models;

namespace Cours.Services;

public interface IUserService {
    Task<IEnumerable<User>> GetUsersAsync();
    Task<Client> Create(User user);
    Task<Client> Update(User user);
    Task<Client> Delete(int id);
}