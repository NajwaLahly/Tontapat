
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
        private const int SURFACE_ANIMAL_JOUR = 5;
        private const int MAX_DUREE_TONTE_LENTE = 30;
        private const int MIN_DUREE_TONTE_LENTE = 10;
        private const int MIN_DUREE_TONTE_MOYENNE = 6;
        private const int MAX_DUREE_TONTE_MOYENNE = 9;
        private const int MIN_DUREE_TONTE_RAPIDE = 2;
        private const int MAX_DUREE_TONTE_RAPIDE = 5;
        private const int HECTARE_TO_M2 = 10000;
        private const int POWER = 3;

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

        public List<OffreDetail> RechercherOffre(RechercheOffreDto rod)
        {
            OffreDAO odao = new();
            TerrainBU tbu = new();
            Terrain terrain = tbu.GetById(rod.IdTerrain);
            int[] duration = GetOffreSearchDuration(rod.IdTypeTonte, terrain.Superficie);
            int[] nbreBetes = GetOffreSearchNbreBetes(rod.IdTypeTonte, terrain.Superficie);
            return (odao.GetSearchResultsWithDetailsByParams(rod, rod.DateDebut.AddDays(duration[0]), rod.DateDebut.AddDays(duration[1]), nbreBetes[0], nbreBetes[1]));
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
            }
            durees[0] += (int)Math.Log10(Math.Pow(surface * HECTARE_TO_M2, (double)POWER))/2;
            durees[1] += (int)Math.Log10(Math.Pow(surface * HECTARE_TO_M2, (double)POWER)) / 2;
            return durees;
        }

        public int[] GetOffreSearchNbreBetes(int? idTypeTonte, double surface)
        {
            OffreBU obu = new();
            int[] minMaxDuree = obu.GetOffreSearchDuration(idTypeTonte, surface);
            
            int[] minMaxBetes = { 0, 0 };
            minMaxBetes[1] = (int)(surface * HECTARE_TO_M2 / (minMaxDuree[0] * SURFACE_ANIMAL_JOUR));
            minMaxBetes[0] = (int)(surface * HECTARE_TO_M2 / (minMaxDuree[1] * SURFACE_ANIMAL_JOUR));

            return minMaxBetes;
        }
        
    }
}
