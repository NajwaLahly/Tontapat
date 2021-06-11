using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Evaluation
    {
        public int Id { get; set; }
        public int IdPrestation { get; set; }
        public int IdUtilisateurCible { get; set; }
        public int Note { get; set; }
        public string Commentaire { get; set; }

        public Evaluation()
        {
        }
    }
}
