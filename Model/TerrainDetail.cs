using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    public class TerrainDetail : Terrain
    {
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Cloture { get; set; }
        public string Type { get; set; }
        public List<TypeVegeToxique> VegetationToxique { get; set; }
    }
}
