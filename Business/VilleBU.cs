﻿using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class VilleBU
    {
        public List<Ville> GetAll()
        {
            VilleDAO dao = new();
            return dao.GetAll();
        }
    }
}
