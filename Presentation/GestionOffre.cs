using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Presentation
{
    class GestionOffre
    {
        public void AddOffre(int idFrequence, int idTroupeau, int idTypeTonte, int idPrestation, int idTarif,
            int idCondition, string nomOffre, bool typeInstallation, DateTime dateAjout, DateTime dateDebut,
            DateTime dateFin, string descriptionOffre, float prixKm, float prixInstallation, float prixIntervention,
            float prixBeteJour, int zoneCouverture, string adresseOffre, DateTime? dateAnnulationOffre)
        {
            Offre o = new(idFrequence, idTroupeau, idTypeTonte, idPrestation, idTarif,
            idCondition, nomOffre, typeInstallation, dateAjout, dateDebut,
            dateFin, descriptionOffre, prixKm, prixInstallation, prixIntervention,
            prixBeteJour, zoneCouverture, adresseOffre, dateAnnulationOffre);

            OffreBU bu = new();
            bu.InsertOffre(o);
        }
    }
}
