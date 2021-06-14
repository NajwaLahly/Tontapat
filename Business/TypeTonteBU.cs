using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class TypeTonteBU
    {

        public List<TypeTonte> GetAll()
        {
            TypeTonteDAO dao = new();
            return dao.GetAll();
        }

        public TypeTonte GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id type de tonte invalide");
            }
            TypeTonteDAO dao = new();
            return dao.GetById(id);
        }
    }
}
