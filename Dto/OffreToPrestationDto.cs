using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Dto
{
    public class OffreToPrestationDto
    {

        public OffreDetail OffreRef { get; set; }
        public int IdOffre { get; set; }
        public Terrain TerrainRef { get; set; }
        public int IdTerrain { get; set; }
        public int? IdTypeTonte { get; set; }
        public double Distance { get; set; }
        public int NbBetes { get; set; }
        public bool? TypeInstallation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int Duree { get; set; }
        public double PrixInstallationBetail { get; set; }
        public double PrixInstallationCloture { get; set; }
        public double PrixBetail { get; set; }
        public double PrixIntervention { get; set; }
        public double PrixService { get; set; }
        public double PrixTVA { get; set; }
        public double PrixTotal { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OffreToPrestationDto dto &&
                   EqualityComparer<OffreDetail>.Default.Equals(OffreRef, dto.OffreRef) &&
                   IdOffre == dto.IdOffre &&
                   EqualityComparer<Terrain>.Default.Equals(TerrainRef, dto.TerrainRef) &&
                   IdTerrain == dto.IdTerrain &&
                   IdTypeTonte == dto.IdTypeTonte &&
                   Distance == dto.Distance &&
                   NbBetes == dto.NbBetes &&
                   TypeInstallation == dto.TypeInstallation &&
                   DateDebut == dto.DateDebut &&
                   DateFin == dto.DateFin &&
                   Duree == dto.Duree &&
                   PrixInstallationBetail == dto.PrixInstallationBetail &&
                   PrixInstallationCloture == dto.PrixInstallationCloture &&
                   PrixBetail == dto.PrixBetail &&
                   PrixIntervention == dto.PrixIntervention &&
                   PrixService == dto.PrixService &&
                   PrixTVA == dto.PrixTVA &&
                   PrixTotal == dto.PrixTotal;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(OffreRef);
            hash.Add(IdOffre);
            hash.Add(TerrainRef);
            hash.Add(IdTerrain);
            hash.Add(IdTypeTonte);
            hash.Add(Distance);
            hash.Add(NbBetes);
            hash.Add(TypeInstallation);
            hash.Add(DateDebut);
            hash.Add(DateFin);
            hash.Add(Duree);
            hash.Add(PrixInstallationBetail);
            hash.Add(PrixInstallationCloture);
            hash.Add(PrixBetail);
            hash.Add(PrixIntervention);
            hash.Add(PrixService);
            hash.Add(PrixTVA);
            hash.Add(PrixTotal);
            return hash.ToHashCode();
        }
    }
}
