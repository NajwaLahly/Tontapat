using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Troupeau
    {
        public int Id { get; set; }
        public int IdRace { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdVille { get; set; }
        public int NombreBetes { get; set; }
        public string NomTroupeau { get; set; }
        public string Description { get; set; }
        public string AdresseVoie { get; set; }
        public float AdresseLong { get; set; }
        public float AdresseLat { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateDisponibilite { get; set; }
        public DateTime DateIndisponibilite { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public DateTime DateRetrait { get; set; }
        public bool Divisibilite { get; set; }

        public Troupeau()
        {
        }
    }
}
