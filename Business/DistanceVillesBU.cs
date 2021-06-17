using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class DistanceVillesBU
    {
        public double GetDistanceBetweenIds(int id1, int id2)
        {
            DistanceVillesDAO dvdao = new();
            return dvdao.GetDistanceBetweenIds(id1, id2);
        }

    }
}
