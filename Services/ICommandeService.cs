using Cours.Models;

namespace Cours.Services;

public interface ICommandeService {
    Task<IEnumerable<Commande>> GetCommandesAsync();
    Task<Commande> Create(Commande client);
    Task<Commande> Update(Commande client);
    Task<Commande> Delete(int id);
}