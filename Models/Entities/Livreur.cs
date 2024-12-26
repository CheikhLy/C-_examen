using System.ComponentModel.DataAnnotations.Schema;

namespace Cours.Models;

    public class Livreur : Personne
    {
        Boolean isAvailable { get; set; }=true;

       [NotMapped]
        public List<Commande> commandes { get; set; }
    }
