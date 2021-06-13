using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class Reclamation
    {
        public int Id { get; set; }
        public int IdPrestation { get; set; }
        public int IdMotif { get; set; }
        public DateTime DateEmission { get; set; }
        public  string Description { get; set; }
        public DateTime DateTraitement { get; set; }
        public DateTime DateFermeture { get; set; }

        public Reclamation()
        {
        }
    }
}
