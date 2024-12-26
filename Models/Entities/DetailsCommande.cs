namespace Cours.Models
{
    public class DetailsCommande: AbstractEntity
    {
        public double  prix { get; set; } 
        public double qteCommande { get; set; }
        public Commande commande { get; set; }
        public int commandeID{ get; set; }
        public Produits produits { get; set; }
        public int produitID { get; set; }

    }
}