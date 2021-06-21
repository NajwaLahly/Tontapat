using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class TerrainBU
    {
        public void Insert(Terrain t)
        {
            //DateRetrait should be > DateTime.Today + 1
            if(t.DateRetrait < DateTime.Today.AddDays(1))
            {
                throw new Exception("Date de retrait invalide");
            }
            TerrainDAO dao = new();
            dao.Create(t);
        }

        public Terrain GetById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Id terrain invalide");
            }
            TerrainDAO dao = new();
            return dao.GetById(id);
        }

       

        public List<Terrain> GetAllByUtilisateurId(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Id terrain invalide");
            }

            TerrainDAO dao = new();
            return dao.GetAllByUtilisateurId(id);
        }

        public List<TerrainDetail> GetAllWithDetailByUtilisateurId(int id)
        {
            TerrainDAO dao = new();
            return dao.GetAllWithDetailByUtilisateurId(id);
        }

        public List<Terrain> GetLatest(int id, int nbre)
        {
            TerrainDAO dao = new();
            return dao.GetLatest(id, nbre);
        }
        public TerrainDetail GetTerrainDetailById(int id)
        {
            TerrainDAO dao = new();
            return dao.GetWithDetailById(id);
        }
    }
}
