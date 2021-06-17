using System;

namespace Fr.EQL.AI109.Tontapat.Dto
{
    public class RechercheOffreDto
    {
        public int IdTerrain { get; set; }
        public double TerrainSuperficie { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFinMin { get; set; }
        public DateTime DateFinMax { get; set; }
        public DateTime DateFin { get; set; }
        public int IdVilleTerrain { get; set; }
        public int NbBetesMin { get; set; }
        public int NbBetesMax { get; set; }
        public int NbBetes { get; set; }
        public int? IdEspece { get; set; }
        public int? IdTypeTonte { get; set; }
        public bool? TypeInstallation { get; set; }
      
    }
}
