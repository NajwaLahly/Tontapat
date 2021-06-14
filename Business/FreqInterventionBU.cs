using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class FreqInterventionBU
    {

        public List<FreqIntervention> GetAll()
        {
            FreqInterventionDAO dao = new();
            return dao.GetAll();
        }

        public FreqIntervention GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id fréquence d'intervention invalide");
            }
            FreqInterventionDAO dao = new();
            return dao.GetById(id);
        }
    }
}
