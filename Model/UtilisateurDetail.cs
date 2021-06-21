using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class UtilisateurDetail : Utilisateur
    {
        public float Evalutation { get; set; } 
        public string NomVille { get; set; }
        public int CodePostal { get; set; }
        public double? Moyenne { get; set; }
        public int NbEvaluation { get; set; }
        public List<EvaluationDetail>? MesEvals { get; set; }
        public List<OffreDetail>? MesOffres { get; set; }
        public List<PrestationDetail>? MesPresta { get; set; }
        public List<TroupeauDetail>? MesTroupeaux { get; set; }
        public List<TerrainDetail>? MesTerrains { get; set; }
    }
}
