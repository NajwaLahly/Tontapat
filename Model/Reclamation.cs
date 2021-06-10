﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Reclamation
    {
        public int Id { get; set; }
        public int IdPrestation { get; set; }
        public int IdMotif { get; set; }
        public DateTime DateReclamation { get; set; }
        public  string DescriptionReclamation { get; set; }
        public DateTime DateTraitement { get; set; }
        public DateTime DateFermeture { get; set; }

        public Reclamation()
        {
        }
    }
}
