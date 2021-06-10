using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Negociation
    {
        public int Id { get; set; }
        public int IdPrestation { get; set; }
        public int IdOffre { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateFermeture { get; set; }

        public Negociation()
        {
        }
    }
}
