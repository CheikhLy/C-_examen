using Cours.Enum;
using Cours.Models;

namespace ges_commande.Models
{
    public  class User : Personne
    {
        public string login { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
      
    }
}