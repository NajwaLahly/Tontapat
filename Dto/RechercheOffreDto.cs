using System;

namespace Fr.EQL.AI109.Tontapat.Dto
{
    public class RechercheOffreDto
    {
        public int IdTerrain { get; set; }
        public DateTime DateDebut { get; set; }
        public int? IdEspece { get; set; }
        public int? IdTypeTonte { get; set; }
        public bool? TypeInstallation { get; set; }
      
    }
}
