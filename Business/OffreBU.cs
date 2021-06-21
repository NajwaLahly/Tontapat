
using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Dto;
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
        private const int HECTARE_TO_M2 = 10000;
        private const int POWER = 3;

        private const int MIN_SURFACE_ANIMAL_LENTE = 50;
        private const int MAX_SURFACE_ANIMAL_LENTE = 1000;
        private const int MIN_SURFACE_ANIMAL_MOYEN = 30;
        private const int MAX_SURFACE_ANIMAL_MOYEN = 49;

        

        private const int MIN_SURFACE_ANIMAL_RAPIDE = 10;
        private const int MAX_SURFACE_ANIMAL_RAPIDE = 29;

        private const int SURFACE_ANIMAL_JOUR = 5;

        private const int MIN_DUREE_TONTE_LENTE = MIN_SURFACE_ANIMAL_LENTE / SURFACE_ANIMAL_JOUR;
        private const int MAX_DUREE_TONTE_LENTE = MAX_SURFACE_ANIMAL_LENTE / SURFACE_ANIMAL_JOUR;
        private const int MIN_DUREE_TONTE_MOYENNE = MIN_SURFACE_ANIMAL_MOYEN / SURFACE_ANIMAL_JOUR;
        private const int MAX_DUREE_TONTE_MOYENNE = MAX_SURFACE_ANIMAL_MOYEN / SURFACE_ANIMAL_JOUR;
        private const int MIN_DUREE_TONTE_RAPIDE = MIN_SURFACE_ANIMAL_RAPIDE / SURFACE_ANIMAL_JOUR;
        private const int MAX_DUREE_TONTE_RAPIDE = MAX_SURFACE_ANIMAL_RAPIDE / SURFACE_ANIMAL_JOUR;

        private const double FRAIS_SERVICE = 0.1;
        private const double TVA = 0.2;
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

        public List<OffreToPrestationDto> RechercherOffre(RechercheOffreDto rod)
        {
            OffreDAO odao = new();

            TerrainDAO tdao = new();
            Terrain t = tdao.GetById(rod.IdTerrain);
            double terrainSuperficie = t.Superficie;
            rod.IdVilleTerrain = t.IdVille;
            int[] duration = GetOffreSearchDuration(rod.IdTypeTonte, terrainSuperficie);
            int nbreBetes = GetOffreSearchNbreBetes(rod, terrainSuperficie);
            rod.NbBetes = nbreBetes;
            //rod.DateFinMin = rod.DateDebut.AddDays(duration[0]);
            //rod.DateFinMax = rod.DateDebut.AddDays(duration[1]);
            

            //rod.NbBetesMin = nbreBetes[0];
            //rod.NbBetesMax = nbreBetes[1];

            List<OffreDetail> ods = odao.GetSearchResultsWithDetailsByParams(rod);
            List<OffreToPrestationDto> otps = new();

            foreach(OffreDetail od in ods)
            {
                OffreToPrestationDto otp = new();
                otp.OffreRef = od;
                otp.IdOffre = otp.OffreRef.Id;
                otp.TerrainRef = t;
                otp.IdTerrain = t.Id;
                otp.IdTypeTonte = rod.IdTypeTonte;
                otp.NbBetes = otp.OffreRef.Divisibilite ? rod.NbBetes : otp.OffreRef.NbBetes;
                otp.TypeInstallation = rod.TypeInstallation;
                otp.DateDebut = rod.DateDebut;
                otp.DateFin = rod.DateFin;

                // ET LA VIENNENT TOUS LES CALCULS QU'ON FAISAIT DANS LA VIEW

                otp.Duree = (int)(otp.DateFin - otp.DateDebut).TotalDays;
                //Calcul distance entre terrain sélectionné et offre
                DistanceVillesBU dvbu = new();

                otp.Distance = Math.Round(dvbu.GetDistanceBetweenIds(otp.TerrainRef.IdVille, otp.OffreRef.IdVilleTroupeau), 1); ;
                otp.PrixInstallationBetail = Math.Round(otp.Distance * otp.OffreRef.PrixKm * otp.NbBetes * od.CoefInstallation * 2, 2); ;
                otp.PrixInstallationCloture = Math.Round(otp.OffreRef.PrixKm * otp.Distance * otp.OffreRef.CoefInstallation * (double)otp.TerrainRef.Superficie * 2 * 100, 2);
                otp.PrixBetail = Math.Round(otp.OffreRef.PrixBeteJour * otp.Duree * otp.NbBetes, 2);
                otp.PrixIntervention = Math.Round(od.CoefIntervention * otp.Distance * od.PrixKm * (int)(otp.Duree / otp.OffreRef.FrequenceIntervention), 2);
                double sousTotal = Math.Round(otp.Distance + otp.PrixInstallationBetail + otp.PrixInstallationCloture + otp.PrixBetail + otp.PrixIntervention,2);
                otp.PrixService = Math.Round(sousTotal * FRAIS_SERVICE,2);
                otp.PrixTVA = Math.Round((sousTotal + otp.PrixService) * TVA,2);
                otp.PrixTotal = Math.Round(sousTotal + otp.PrixService + otp.PrixTVA,2);

                //On ajoute notre objet tout propre dans la liste
                // qu'on affichera sur la view
                otps.Add(otp);
            }

            return otps;
        }

        public OffreToPrestationDto GetOffreToPrestation(OffreToPrestationDto otpdto)
        {
            OffreDAO odao = new();
            otpdto.OffreRef = odao.GetWithDetailsById(otpdto.IdOffre);

            TerrainBU tbu = new();
            otpdto.TerrainRef = tbu.GetById(otpdto.IdTerrain);

            return otpdto;
        }
        public List<OffreDetail> GetAllWithDetails()
        {
            return new OffreDAO().GetAllWithDetails();
        }

        public OffreDetail GetWithDetailsById(int id)
        {
            OffreDAO dao = new();
            return dao.GetWithDetailsById(id);
        }

        public List<OffreDetail> GetAllWithDetailsByUtilisateurId(int id)
        {
            return new OffreDAO().GetAllWithDetailsByUtilisateurId(id);
        }

        public int[] GetOffreSearchDuration(int? idTypeTonte, double surface)
        {
            int[] durees = { 0, 0};
            switch (idTypeTonte){
                case 1:
                    
                    durees[0] = MIN_DUREE_TONTE_LENTE;
                    durees[1] = MAX_DUREE_TONTE_LENTE;
                    break;
                case 2:
                    durees[0] = MIN_DUREE_TONTE_MOYENNE;
                    durees[1] = MAX_DUREE_TONTE_MOYENNE;
                    break;
                case 3:
                    durees[0] = MIN_DUREE_TONTE_RAPIDE;
                    durees[1] = MAX_DUREE_TONTE_RAPIDE;
                    break;
                case 4:
                    durees[0] = MIN_DUREE_TONTE_LENTE;
                    durees[1] = MAX_DUREE_TONTE_LENTE;
                    break;
            }
            durees[0] += (int)Math.Log10(Math.Pow(surface * HECTARE_TO_M2, (double)POWER))/2;
            durees[1] += (int)Math.Log10(Math.Pow(surface * HECTARE_TO_M2, (double)POWER)) / 2;
            return durees;
        }

       /* public int[] GetOffreSearchNbreBetes(RechercheOffreDto rod, double superficie)
        {
            OffreBU obu = new();
            int[] minMaxDuree = obu.GetOffreSearchDuration(rod.IdTypeTonte, superficie);
            
            int[] minMaxBetes = { 0, 0 };
            minMaxBetes[1] = (int)(superficie * HECTARE_TO_M2 / (minMaxDuree[0] * SURFACE_ANIMAL_JOUR));
            minMaxBetes[0] = (int)(superficie * HECTARE_TO_M2 / (minMaxDuree[1] * SURFACE_ANIMAL_JOUR));

            if (minMaxBetes[0] == 0)
            {
                minMaxBetes[0] = 1;
            }
            return minMaxBetes;
        }*/

        public int GetOffreSearchNbreBetes(RechercheOffreDto rod, double superficie)
        {
            OffreBU obu = new();
            int[] minMaxDuree = obu.GetOffreSearchDuration(rod.IdTypeTonte, superficie);

            int nbreBetes = (int)(superficie * HECTARE_TO_M2 / ((rod.DateFin - rod.DateDebut).TotalDays * SURFACE_ANIMAL_JOUR));


            if (nbreBetes == 0)
            {
                nbreBetes = 1;
            }
            return nbreBetes;
        }
        public List<OffreDetail> GetLatest(int nbre)
        {
            OffreDAO dao = new();
            return dao.GetLatest(nbre);
        }


    }
}
