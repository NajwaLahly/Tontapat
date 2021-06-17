using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class EvaluationBU
    {
        public List<EvaluationDetail> GetAllWithDetailsByClientId(int id)
        {
            EvaluationDAO dao = new();
            return dao.GetAllWithDetailsByClientId(id);
        }

        public List<EvaluationDetail> GetAllWithDetailsByEleveurId(int id)
        {
            EvaluationDAO dao = new();
            return dao.GetAllWithDetailsByEleveurId(id);
        }

        public List<EvaluationDetail> GetAllWithDetailsByOffreId(int idOffre)
        {
            EvaluationDAO dao = new();
            return dao.GetAllWithDetailsByOffreId(idOffre);
        }

    }
}
