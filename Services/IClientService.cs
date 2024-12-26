using Cours.Models;

namespace Cours.Services;

public interface IClientService{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> Create(Client client);
    Task<Client> Update(Client client);
    Task<Client> Delete(int id);
    Task<Commande> CreateCommande(int clientId, int produitId, int quantite);
    }