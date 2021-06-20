using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
   public class TroupeauDetail : Troupeau
    {
        public string Race { get; set; }
        public string Espece { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }

    }
}
