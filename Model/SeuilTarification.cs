﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class SeuilTarification
    {
        public int Id { get; set; }
        public string NomSeuil { get; set; }
        public float PrixKm { get; set; }
        public float PrixBeteJour { get; set; }
        public float CoefIntervention { get; set; }
        public float CoefInstallation { get; set; }

        public SeuilTarification()
        {
        }
    }
}
