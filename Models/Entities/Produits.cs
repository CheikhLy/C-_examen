using System.ComponentModel.DataAnnotations.Schema;

namespace Cours.Models
{
    public class Produits: AbstractEntity
    {
        public string Libelle { get; set; }
        public double Prix { get; set; } 
        public int Quantite { get; set; }
        [NotMapped]
        public List<DetailsCommande> DetailsCommandes { get; set; }


    }
}