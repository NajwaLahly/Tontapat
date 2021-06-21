using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Terrain
    {
        public int Id { get; set; }
        public int IdVille { get; set; }
        public int IdCloture { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdTypeTerrain { get; set; }
        public string Nom { get; set; }
        public float Superficie { get; set; }
        public  string Description { get; set; }
        public DateTime DateAjout { get; set; }
        public bool AccesPublic { get; set; }
        public float? AdresseLat { get; set; }
        public float? AdresseLong { get; set; }
        public string AdresseVoie { get; set; }
        public string? Photo1 { get; set; }
        public string? Photo2 { get; set; }
        public string? Photo3 { get; set; }
        public string? Photo4 { get; set; }
        public string? Photo5 { get; set; }
        public DateTime? DateRetrait { get; set; }
        public bool PresenceCamera { get; set; }
        public bool ServiceSecurite { get; set; }

        public Terrain()
        {
        }

        public Terrain(int id, int idVille, int idCloture, int idUtilisateur,
            int idTypeTerrain, string nom, float superficie, string description,
            DateTime dateAjout, bool accesPublic, float adresseLat, float adresseLong,
            string adresseVoie, string photo1, string photo2, string photo3,
            string photo4, string photo5, DateTime dateRetrait, bool presenceCamera,
            bool serviceSecurite)
        {
            Id = id;
            IdVille = idVille;
            IdCloture = idCloture;
            IdUtilisateur = idUtilisateur;
            IdTypeTerrain = idTypeTerrain;
            Nom = nom;
            Superficie = superficie;
            Description = description;
            DateAjout = dateAjout;
            AccesPublic = accesPublic;
            AdresseLat = adresseLat;
            AdresseLong = adresseLong;
            AdresseVoie = adresseVoie;
            Photo1 = photo1;
            Photo2 = photo2;
            Photo3 = photo3;
            Photo4 = photo4;
            Photo5 = photo5;
            DateRetrait = dateRetrait;
            PresenceCamera = presenceCamera;
            ServiceSecurite = serviceSecurite;
        }
    }
}
