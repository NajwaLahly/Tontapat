using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class PropositionDetail : Proposition
    {

        public int IdPrestation { get; set; }

        public string NomTypeTonte { get; set; }

        public string NomTerrain { get; set; }
    }
}
