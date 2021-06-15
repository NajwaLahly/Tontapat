using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class UtilisateurDetail : Utilisateur
    {
        public float Evalutation { get; set; } 
        public string NomVille { get; set; }
        public double? Moyenne { get; set; }
    }
}
