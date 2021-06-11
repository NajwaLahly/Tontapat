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
        public void AddOffre(int idFrequence, int idTroupeau, int idTypeTonte, 
            int idCondition, string nomOffre, bool typeInstallation, DateTime dateAjout, DateTime dateDebut,
            DateTime dateFin, string descriptionOffre, float prixKm, float coefInstallation, float coefIntervention,
            float prixBeteJour, int zoneCouverture, string adresseOffre, DateTime? dateAnnulationOffre)
        {
            Offre o = new(idFrequence, idTroupeau, idTypeTonte, 
            idCondition, nomOffre, typeInstallation, dateAjout, dateDebut,
            dateFin, descriptionOffre, prixKm, coefInstallation, coefIntervention,
            prixBeteJour, zoneCouverture, adresseOffre, dateAnnulationOffre);

            OffreBU bu = new();
            bu.InsertOffre(o);
        }

        public List<Offre> GetAll()
        {
            OffreBU bu = new();
            return bu.GetAll();
        }

        public Offre GetById(int id)
        {
            OffreBU bu = new();
            return bu.GetById(id);
        }
    }
}
