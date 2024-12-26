using Cours.Models;

namespace Cours.Services;

public interface IPersonneService{
    Task<IEnumerable<Personne>> GetPersonneAsync();
    Task<Client> Create(Personne personne);
    Task<Client> Update(Personne personne);
    Task<Client> Delete(int id);
}