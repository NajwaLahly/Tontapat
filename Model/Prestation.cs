using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Prestation
    {
        public int Id { get; set; }
        public int IdMotifAnnulation { get; set; }
        public int IdTerrain { get; set; }
        public int IdTroupeau { get; set; }
        public int IdOffre { get; set; }
        public int NombreBetes { get; set; }
        public int IdMotifRefus { get; set; }
        public DateTime DateDemande { get; set; }
        public DateTime DateValidation { get; set; }
        public DateTime DateRefus { get; set; }
        public string DescriptionRefus { get; set; }
        public DateTime DateAnnulation { get; set; }
        public string DescriptionAnnulation { get; set; }
        public float PrixConvenu { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool TypeInstallationFinal { get; set; }

        public Prestation()
        {
        }
    }
}
