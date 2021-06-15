using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class OffreDetail : Offre
    {
        public string TypeTonte { get; set; }
        public string PrenomEleveur { get; set; }
        public string VilleTroupeau { get; set; }
        public string Race { get; set; }
        public string Espece { get; set; }
        public int IdUtilisateur { get; set; }
        public string Condition { get; set; }
        public int IdEspece { get; set; }
        public double? Moyenne { get; set; }
    }
}
