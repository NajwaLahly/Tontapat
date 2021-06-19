using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Prestation
    {
        public int Id { get; set; }
        public int IdMotifAnnulation { get; set; }
        public int IdTerrain { get; set; }
        public int IdTroupeau { get; set; }
        public int IdOffre { get; set; }
        public int IdTypeTonte { get; set; }
        public int NombreBetes { get; set; }
        public int IdMotifRefus { get; set; }
        public DateTime DateDemande { get; set; }
        public DateTime DateValidation { get; set; }
        public DateTime DateRefus { get; set; }
        public string DescriptionRefus { get; set; }
        public DateTime DateAnnulation { get; set; }
        public string DescriptionAnnulation { get; set; }
        public double PrixConvenu { get; set; }
        public double PrixInstallationCloture { get; set; }
        public double PrixInstallationBetail { get; set; }
        public double PrixBetail { get; set; }
        public double PrixIntervention { get; set; }
        public double PrixService { get; set; }
        public double PrixTVA { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool TypeInstallationFinal { get; set; }
        public int IdAncienne { get; set; }
        public int FrequenceIntervention { get; set; }
        public int IdConditionsAnnulation { get; set; }

        public Prestation()
        {
        }

        public Prestation(int id, int idMotifAnnulation, int idOffre, int idTerrain,
            int idTroupeau, int idMotifRefus, int nombreBetes, DateTime dateDemande,
            DateTime dateValidation, DateTime dateRefus, string descriptionRefus,
            DateTime dateAnnulation, string descriptionAnnulation, float prixConvenu,
            DateTime dateDebut, DateTime dateFin, bool typeInstallationFinal)
        {
            Id = id;
            IdMotifAnnulation = idMotifAnnulation;
            IdOffre = idOffre;
            IdTerrain = idTerrain;
            IdTroupeau = idTroupeau;
            IdMotifRefus = idMotifRefus;
            NombreBetes = nombreBetes;
            DateDemande = dateDemande;
            DateValidation = dateValidation;
            DateRefus = dateRefus;
            DescriptionRefus = descriptionRefus;
            DateAnnulation = dateAnnulation;
            DescriptionAnnulation = descriptionAnnulation;
            PrixConvenu = prixConvenu;
            DateDebut = dateDebut;
            DateFin = DateFin;
            TypeInstallationFinal = typeInstallationFinal;
        }
    }
}
