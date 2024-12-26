using Cours.Models;
using Cours.Enum;
using ges_commande.Models;
namespace gestioncommande.Data.Fixtures
{
    public static class Fixtures
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            // Vérifier si des données existent déjà dans la table Clients


            // Ajouter des clients par défaut
            var Users = new List<User>();
            var clients = new List<Client>();


            for (int i = 0; i < 3; i++)
            {
                var roles = new Role[] { Role.Client, Role.Comptable, Role.RS };
                Users.Add(new User
                {

                    Nom = $"Nom{i + 1}",
                    Prenom = $"Prenom{i + 1}",
                    login = $"Login{i + 1}",
                    password = $"Password{i + 1}",
                    Telephone = $"telephone{i + 1}",
                    role = roles[i % roles.Length],

                });

            };

            for (int i = 0; i < 3; i++)
            {
                var user = new User
                {
                    Telephone = $"telephone{i + 1}",
                    Nom = $"Nom{i + 1}",
                    Prenom = $"Prenom{i + 1}",
                    login = $"Login{i + 1}",
                    password = $"Password{i + 1}",
                };
                Users.Add(user);

                clients.Add(new Client
                {
                    Adresse = $"adresse{i + 1}",
                    user = user,
                });
            };

            context.users.AddRange(Users);
            context.client.AddRange(clients);
        }


    }


}