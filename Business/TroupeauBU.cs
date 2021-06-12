using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class TroupeauBU
    {
        public void Insert(Troupeau t)
        {
            //DateDisponibilite should be >= DateTime.Today
            if (t.DateDisponibilite < DateTime.Now)
            {
                throw new Exception("Date de disponibilité invalide");
            }

            //DateIndisponibilite should be >= DateTime.Today
            if (t.DateIndisponibilite < DateTime.Now)
            {
                throw new Exception("Date d'indisponibilité invalide");
            }

            TroupeauDAO dao = new();
            dao.Create(t);
        }

        public Troupeau GetById(int id)
        {
            //Id should be > 0
            if (id <= 0)
            {
                throw new Exception("Id de troupeau invalide");
            }
            TroupeauDAO dao = new();
            return dao.GetById(id);
        }
    }
}