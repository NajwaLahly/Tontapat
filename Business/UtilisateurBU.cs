using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class UtilisateurBU
    {
        public void InsertUtilisateur(Utilisateur u)
        {
            if(u.DateNaissance.AddYears(18) > DateTime.Now)
            {
                throw new Exception("Age inférieur 18 ans.");
            }

            UtilisateurDAO dao = new();
            dao.Create(u);
        }

        public Utilisateur GetById(int id)
        {
            UtilisateurDAO dao = new();
            return dao.GetById(id);
        }

        public List<Utilisateur> GetAll()
        {
            UtilisateurDAO dao = new();
            return dao.GetAll();
        }
        public UtilisateurDetail GetAllWithDetailById(int id)
        {
            UtilisateurDAO dao = new();


            UtilisateurDetail ud= dao.GetAllWithDetailsById(id);
            EvaluationBU ebu= new();
            TroupeauBU tbu = new();
            TerrainBU terbu = new();
            ud.MesTerrains = terbu.GetAllWithDetailByUtilisateurId(id);
            ud.MesTroupeaux = tbu.GetAllWithDetailByutilisateurId(id);
            ud.MesEvals = ebu.GetAllWithDetailsByUtilisateurId(id);

            return ud;
        }
        public void MAJ(UtilisateurDetail d)
        {
            UtilisateurDAO dao = new();
            dao.Update(d);
        }
    }
}
