using Cours.Enum;

namespace Cours.Models
{
    public class Paiements : AbstractEntity
    {
       
    TypePaiement TypePaiement { get; set; }
    public Commande commande { get; set; }
    public int commandeId { get; set; }
    public Boolean reduction { get; set; }=false;
    public TypePaiement typePaiement { get; set; }
    }
}