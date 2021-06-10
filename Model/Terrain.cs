using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Terrain
    {
        public int Id { get; set; }
        public int IdVille { get; set; }
        public int IdCloture { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdTypeTerrain { get; set; }
        public string NomTerrain { get; set; }
        public float SuperficieTerrain { get; set; }
        public  string Description { get; set; }
        public DateTime DateAjout { get; set; }
        public bool AccesPublic { get; set; }
        public float AdresseLat { get; set; }
        public float AdresseLong { get; set; }
        public string AdresseVoie { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public DateTime DateRetraitTerrain { get; set; }
        public bool PresenceCamera { get; set; }
        public bool ServiceSecurite { get; set; }

        public Terrain()
        {
        }
    }
}
