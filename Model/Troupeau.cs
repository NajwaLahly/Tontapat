using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Troupeau
    {
        public int Id { get; set; }
        public int IdRace { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdVille { get; set; }
        public int NombreBetes { get; set; }
        public string NomTroupeau { get; set; }
        public string Description { get; set; }
        public string AdresseVoie { get; set; }
        public float? AdresseLong { get; set; }
        public float? AdresseLat { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateDisponibilite { get; set; }
        public DateTime? DateIndisponibilite { get; set; }
        public string? Photo1 { get; set; }
        public string? Photo2 { get; set; }
        public string? Photo3 { get; set; }
        public string? Photo4 { get; set; }
        public string? Photo5 { get; set; }
        public DateTime? DateRetrait { get; set; }
        public bool Divisibilite { get; set; }

        public Troupeau()
        {
        }

        public Troupeau(int id, int idRace, int idUtilisateur, int idVille, int nombreBetes,
            string nomTroupeau, string description, string adresseVoie, float adresseLong,
            float adresseLat, DateTime dateAjout, DateTime dateDisponibilite,
            DateTime dateIndisponibilite, string photo1, string photo2, string photo3,
            string photo4, string photo5, DateTime dateRetrait, bool divisibilite)
        {
            Id = id;
            IdRace = idRace;
            IdUtilisateur = idUtilisateur;
            IdVille = idVille;
            NombreBetes = nombreBetes;
            NomTroupeau = nomTroupeau;
            Description = description;
            AdresseVoie = adresseVoie;
            AdresseLong = adresseLong;
            AdresseLat = adresseLat;
            DateAjout = dateAjout;
            DateDisponibilite = dateDisponibilite;
            DateIndisponibilite = dateIndisponibilite;
            Photo1 = photo1;
            Photo2 = photo2;
            Photo3 = photo3;
            Photo4 = photo4;
            Photo5 = photo5;
            DateRetrait = dateRetrait;
            Divisibilite = divisibilite;
        }
    }
}
