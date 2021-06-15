using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class EvaluationDetail : Evaluation
    {
        public string PrenomCible { get; set; }
        public int IdOffre { get; set; }
        public int IdTiers { get; set; }
        public string PrenomTiers { get; set; }
    }
}
