using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Dto
{
    public class OffreToPrestation
    {
        public OffreDetail OffreRef { get; set; }
        public Terrain TerrainRef { get; set; }
        public TypeTonte TypeTonteRef { get; set; }
        public double Distance { get; set; }
        public int NbBetes { get; set; }
        public bool? TypeInstallation { get; set; }
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
