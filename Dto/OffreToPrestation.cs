using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Dto
{
    class OffreToPrestation
    {
        public OffreDetail IdOffre { get; set; }
        public double Distance { get; set; }
        public int NbBetes { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public double PrixInstallationBetail { get; set; }
        public double PrixInstallationCloture { get; set; }
        public double PrixBetail { get; set; }
        public double PrixIntervention { get; set; }
        public double PrixService { get; set; }
        public double PrixTotal { get; set; }

    }
}
