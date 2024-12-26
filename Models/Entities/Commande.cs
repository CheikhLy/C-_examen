using System.ComponentModel.DataAnnotations.Schema;
using Cours.Enum;

namespace Cours.Models
{
    public class Commande:AbstractEntity
    {
       public DateTime DateCommande { get; set; }
       public double PrixTotal { get; set; }
       public Client Client { get; set; }
       public int ClientId { get; set; }
       public Livreur livreur{ get; set; }
       public int LivreurId { get; set; }

       public Paiements paiements { get; set; }
       public int paiementId { get; set; }
       [NotMapped]
       public List<DetailsCommande> detailsCommandes { get; set; }   
       public  Etat etat { get; set; }
       
    }
}