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

        public void RefuseProposition(int id)
        {

        }

        public void SendContreProposition(int id, PropositionDetail pd)
        {
            RefuseProposition(id);
            Insert(pd);

        }
        public void FaireRepondreEleveur(int id)
        {
            PropositionDetail pd = new();
            pd.DateCreation = DateTime.Now;
            pd.Description = "Salut Charles-Henri, j'espère que votre oral se passe bien, hors de question de commencer la prestation à cette date, par contre je suis dispo à partir du 27 juillet. Prends soin de toi petit hipster.";
            pd.DateDebutPrestation = new DateTime(2021,07,27);

            SendContreProposition(id,pd);
        }
    }
}
