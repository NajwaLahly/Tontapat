using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Presentation
{
    class GestionPrestation
    {
        public void AddPrestation(int idOffre, int idTerrain, int idTroupeau, int nombreBetes,
            DateTime dateDemande, DateTime dateValidation, float prixConvenu, DateTime dateDebut,
            DateTime dateFin, bool typeInstallationFinal)
        {
            Prestation p = new(idOffre, idTerrain, idTroupeau, nombreBetes,
            dateDemande, dateValidation, prixConvenu, dateDebut,
            dateFin, typeInstallationFinal);

            PrestationBU bu = new();
            bu.Insert(p);
        }
    }
}
