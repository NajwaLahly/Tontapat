using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Offre
    {
        public int Id { get; set; }
        public int IdFrequence { get; set; }
        public int IdTroupeau { get; set; }
        public int IdTypeTonte { get; set; }
        public int IdPrestation { get; set; }
        public int IdTarif { get; set; }
        public int IdCondition { get; set; }
        public string NomOffre { get; set; }
        public bool TypeInstallation { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string DescriptionOffre { get; set; }
        public float PrixKm { get; set; }
        public float PrixInstallation { get; set; }
        public float PrixIntervention { get; set; }
        public float PrixBeteJour { get; set; }
        public int ZoneCouverture { get; set; }
        public string AdresseOffre { get; set; }
        public DateTime DateAnnulationOffre { get; set; }

        public Offre()
        {
        }
    }
}
