using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Offre
    {
        public int Id { get; set; }
        public int FrequenceIntervention { get; set; }
        public int IdTroupeau { get; set; }
        public int IdTypeTonte { get; set; }
        public int IdCondition { get; set; }
        public string NomOffre { get; set; }
        public bool TypeInstallation { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string DescriptionOffre { get; set; }
        public float PrixKm { get; set; }
        public float CoefInstallation { get; set; }
        public float CoefIntervention { get; set; }
        public float PrixBeteJour { get; set; }
        public int ZoneCouverture { get; set; }
        public string AdresseOffre { get; set; }
        public DateTime? DateAnnulationOffre { get; set; }

        public Offre()
        {
        }

        public Offre(int frequenceIntervention, int idTroupeau, int idTypeTonte, int idCondition, string nomOffre, 
            bool typeInstallation, DateTime dateAjout, DateTime dateDebut, DateTime dateFin, string descriptionOffre,
            float prixKm, float coefInstallation, float coefIntervention, float prixBeteJour, int zoneCouverture, string adresseOffre, DateTime? dateAnnulationOffre)
        {

            FrequenceIntervention = frequenceIntervention;
            IdTroupeau = idTroupeau;
            IdTypeTonte = idTypeTonte;
            IdCondition = idCondition;
            NomOffre = nomOffre;
            TypeInstallation = typeInstallation;
            DateAjout = dateAjout;
            DateDebut = dateDebut;
            DateFin = dateFin;
            DescriptionOffre = descriptionOffre;
            PrixKm = prixKm;
            CoefInstallation = coefInstallation;
            CoefIntervention = coefIntervention;
            PrixBeteJour = prixBeteJour;
            ZoneCouverture = zoneCouverture;
            AdresseOffre = adresseOffre;
            DateAnnulationOffre = dateAnnulationOffre;
        }
    }
}
