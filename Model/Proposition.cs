using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Proposition
    {
        public int Id { get; set; }
        public int IdNegociation { get; set; }
        public int IdUtilisateur { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateAnnulation { get; set; }
        public DateTime? DateValidation { get; set; }
        public DateTime? DateRefus { get; set; }
        public string Description { get; set; }
        public DateTime? DateDebutPrestation { get; set; }
        public DateTime? DateFinPrestation { get; set; }
        public double? PrixPropose { get; set; }
        public bool? TypeInstallation { get; set; }
        public int? IdTerrain { get; set; }

        public Proposition()
        {
        }
    }
}
