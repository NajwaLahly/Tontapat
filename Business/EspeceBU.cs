﻿using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class EspeceBU
    {

        public List<Espece> GetAll()
        {
            EspeceDAO dao = new();
            return dao.GetAll();
        }
    }
}
