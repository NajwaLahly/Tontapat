using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Presentation
{
    class GestionUtilisateur
    {
        public void AddOffre()
        {
            string nom = "Robin";
            string prenom = "Desbois";
            int idville = 1;
            string adresse = "10 Rue de la Forêt";
            string adresseEmail = "peterpan@anime.fr";
            string mdp = "panpan123";
            DateTime naissance = new DateTime(1990, 1, 1, 8, 30,0);
            DateTime inscription = DateTime.Now;
            string raison = "Les Bois à Robin";
            string presentation = "Salut les amis, je m'appelle Robin Desbois et j'aimerai avoir des petits animaux dans ma forêt!";

            Utilisateur u = new Utilisateur();
            u.Nom = nom;
            u.Prenom = prenom;
            u.IdVille = idville;
            u.Email = adresseEmail;
            u.MotDePasse = ComputeSha256Hash(mdp);
            u.AdresseVoie = adresse;
            u.DateNaissance = naissance;
            u.DateInscription = inscription;
            u.RaisonSociale = raison;
            u.Presentation = presentation;

            UtilisateurBU bu = new();
            bu.InsertUtilisateur(u);

        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public Utilisateur GetById(int id)
        {
            UtilisateurBU bu = new();
            return bu.GetById(id);
        }
        public List<Utilisateur> GetAll()
        {
            UtilisateurBU bu = new();
            return bu.GetAll();
        }

    }
}
