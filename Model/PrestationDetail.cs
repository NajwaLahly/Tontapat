using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class PrestationDetail : Prestation
    {
        public string NomTerrain { get; set; }

        public int IdEleveur { get; set; }

        public string PrenomEleveur { get; set; }
        public int IdEspeceTroupeau { get; set; }
        public string NomRaceTroupeau { get; set; }

        public string NomTypeTonte { get; set; }
        public string NomVille { get; set; }

        public ConditionAnnulation ConditionAnnulationRef { get; set; }

        public List<NegociationDetail> Negociations { get; set; }

        public List<InterventionDetail> Interventions { get; set; }

        public double? Distance { get; set; }
        public int IdClient { get; set; }

        public string NomOffre { get; set; }
    }
}
