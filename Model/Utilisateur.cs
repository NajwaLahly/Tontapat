using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public int IdVille { get; set; }
        public  int IdTypeClient { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateInscription { get; set; }
        public string PhotoProfil { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string RaisonSociale { get; set; }
        public string AdresseVoie { get; set; }
        public float AdresseLong { get; set; }
        public float AdresseLat { get; set; }
        public long CarteNumero { get; set; }
        public DateTime CarteExpiration { get; set; }
        public int CarteCVC { get; set; }
        public string VirementIBAN { get; set; }
        public string BIC { get; set; }
        public string PayPalEmail { get; set; }
        public string Presentation { get; set; }

        public Utilisateur()
        {
        }
    }
}
