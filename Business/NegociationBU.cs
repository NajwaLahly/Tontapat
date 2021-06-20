using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class NegociationBU
    {

        public void OpenNegociationInPrestation(int id,Proposition p)
        {
            Negociation n = new();
            n.DateOuverture = DateTime.Now;
            n.IdPrestation = id;
            NegociationDAO ndao = new();
            n.Id = ndao.Create(n);
            p.IdNegociation = n.Id;
            PropositionBU pbu = new();
            pbu.Insert(p);
        }

        public List<NegociationDetail> GetAllWithDetailsByPrestationId(int id)
        {
            List<NegociationDetail> result = new();
            NegociationDAO ndao = new();
            result = ndao.GetAllWithDetailsByPrestationId(id);
            PropositionBU pbu = new();
            foreach (NegociationDetail nd in result)
            {
                nd.Propositions = pbu.GetAllByNegociationId(nd.Id);
            }
            return result;
        }

        public NegociationDetail GetWithDetailsById(int id)
        {
            NegociationDAO ndao = new();
            return ndao.GetWithDetailsById(id);
        }

        public void CloseNegociationWithPropositionAndNewPrestationId(Proposition p)
        {
            Negociation n = new();
            n.DateFermeture = DateTime.Now;
            n.Id = p.IdNegociation;
            if(p.DateValidation != null)
            {

            }
        }

        public void CloseNegociationById(int id)
        {
            Negociation n = new();
            n.Id = id;
            n.DateFermeture = DateTime.Now;
            NegociationDAO ndao = new();
            ndao.Update(n);
        }
    }
}
