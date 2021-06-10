using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Intervention
    {
        public int Id { get; set; }
        public int IdMotif { get; set; }
        public int IdPrestation { get; set; }
        public DateTime DateDemande { get; set; }
        public string DescriptionDemande { get; set; }
        public DateTime DateValidationDemande { get; set; }
        public DateTime DateRefusDemande { get; set; }
        public DateTime DateIntervention { get; set; }
        public DateTime DateValidationIntervention { get; set; }
        public string DescriptionValidation { get; set; }

        public Intervention()
        {
        }
    }
}
