using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class ConditionAnnulation
    {
        public int Id { get; set; }
        public string NomCondition { get; set; }
        public int DelaiJour { get; set; }
        public float PourcentageFacturation { get; set; }

        public ConditionAnnulation()
        {
        }
    }
}
