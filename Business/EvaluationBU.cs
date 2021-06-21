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
        public void Insert(Evaluation e)
        {
            EvaluationDAO dao = new();
            dao.Create(e);
        }
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
        public List<EvaluationDetail> GetAllWithDetailsByUtilisateurId(int id)
        {
            EvaluationDAO dao = new();
            return dao.GetAllWithDetailsByUtilisateurId(id);
        }

        public List<Evaluation> GetAllByPrestationId(int id)
        {
            EvaluationDAO edao = new();
            return edao.GetAllByPrestationId(id);
        }

        public bool IsAlreadyEvaluee(int idPrestation, int idUtilisateurCible)
        {
            EvaluationDAO edao = new();
            List<Evaluation> evaluations = edao.GetAllByPrestationId(idPrestation);
            foreach(Evaluation e in evaluations)
            {
                if(e.IdUtilisateurCible == idUtilisateurCible)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
