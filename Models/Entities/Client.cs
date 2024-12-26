using System.ComponentModel.DataAnnotations.Schema;
using ges_commande.Models;

namespace Cours.Models
{
    public class Client : AbstractEntity
    {
        public double Solde { get; set; }
        public User user { get; set; }

       public String Adresse { get; set; }
        [NotMapped]
        public List<Commande> commandes { get; set; }
    }
}