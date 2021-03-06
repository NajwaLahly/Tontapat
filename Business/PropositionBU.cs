using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class PropositionBU
    {

        public void Insert(PropositionDetail pd)
        {
            PropositionDAO pdao = new();
            pdao.Create(pd);

        }
        public List<Proposition> GetAllByNegociationId(int id)
        {
            PropositionDAO pdao = new();
            return pdao.GetAllByNegociationId(id);
        }

        public PropositionDetail GetWithDetailsById(int id)
        {
            PropositionDetail pd = new();
            PropositionDAO pdao = new();
            pd = pdao.GetWithDetailsById(id);
            if(pd.IdTerrain > 0)
            {
               // TerrainBU tbu = new();
                //pd.TerrainRef = tbu.GetById((int)pd.IdTerrain);
            }
            return pd;
        }

        public void CancelProposition(PropositionDetail prod)
        {
            PropositionDetail pd2 = GetWithDetailsById((int)prod.Id);
            PrestationBU prebu = new();
            PrestationDetail pred = prebu.GetWithDetailsById(pd2.IdPrestation);

            if (pred.Negociations != null)
            {
                if (pred.Negociations.Last().Propositions.Count == 1)
                {
                    NegociationBU nbu = new();
                    nbu.CloseNegociationById(pred.Negociations.Last().Id);
                }
            }

            Proposition p = new();
            p.Id = prod.Id;
            p.DateAnnulation = DateTime.Now;

            PropositionDAO pdao = new();
            pdao.Update(p);

        }
        
        public void RefuseProposition(int id)
        {
            PropositionDAO pdao = new();
            Proposition p = new();
            p.Id = id;
            p.DateRefus = DateTime.Now;
            pdao.Update(p);
        }

        public void SendContreProposition(int id, PropositionDetail pd)
        {
            RefuseProposition(id);
            Insert(pd);

        }

    }
}
