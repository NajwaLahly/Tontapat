using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class OffreBU
    {
        public void InsertOffre(Offre o)
        {
            //start date of an offre should be > DataTime now + 1 day
            if(o.DateDebut < DateTime.Now.AddDays(1))
            {
                throw new Exception("date debut invalide");
            }

            if (o.DateFin < o.DateDebut)
            {
                throw new Exception("date fin invalide");
            }

            OffreDAO dao = new();
            dao.Create(o);
            Console.WriteLine("create executée");
        }

        public List<Offre> GetAll()
        {
            OffreDAO dao = new();
            return dao.GetAll();
        }

        public Offre GetById(int id)
        {
            OffreDAO dao = new();
            return dao.GetById(id);
        }

        public List<OffreDetail> GetAllWithDetails()
        {
            return new OffreDAO().GetAllWithDetails();
        }
    }
}
