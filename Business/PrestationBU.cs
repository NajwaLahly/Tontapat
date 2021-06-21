using Fr.EQL.AI109.Tontapat.DataAccess;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fr.EQL.AI109.Tontapat.Dto;

namespace Fr.EQL.AI109.Tontapat.Business
{
    public class PrestationBU
    {
        public void Insert(Prestation p)
        {
            //Start date of a Prestation should be > DataTime now + 2 days
            /*if (p.DateDebut < DateTime.Now.AddDays(2))
            {
                throw new Exception("Date de début invalide");
            }*/

            /*//End date should be > Start date
            if (p.DateFin < p.DateDebut)
            {
                throw new Exception("Date de fin invalide");
            }

            //Prix convenu should be > 0
            if (p.PrixConvenu <= 0)
            {
                throw new Exception("Prix convenu invalide");
            }

            //Nombre de bêtes should be > 0
            if (p.NombreBetes <= 0)
            {
                throw new Exception("Nombre de bêtes invalide");
            }*/
            PrestationDAO dao = new();
            dao.Create(p);
        }

       

        public void ConvertAndInsert(OffreToPrestationDto otpdto)
        {

            Prestation p = ConvertToPrestation(otpdto);
            Insert(p);
        }

        private Prestation ConvertToPrestation(OffreToPrestationDto otpdto)
        {
            Prestation p = new();
            p.DateDebut = Convert.ToDateTime(otpdto.DateDebut.ToString("yyyy-MM-dd HH:mm:ss"));
            p.DateFin = Convert.ToDateTime(otpdto.DateFin.ToString("yyyy-MM-dd HH:mm:ss")); 
            p.IdTerrain = otpdto.IdTerrain;
            p.IdOffre = otpdto.IdOffre;
            p.IdTroupeau = otpdto.OffreRef.IdTroupeau;
            p.NombreBetes = otpdto.NbBetes;
            p.DateDemande = DateTime.Now;
            p.PrixConvenu = (float)Math.Round(otpdto.PrixTotal,2);
            p.PrixInstallationCloture = (float)Math.Round(otpdto.PrixInstallationCloture,2);
            p.PrixInstallationBetail = (float)Math.Round(otpdto.PrixInstallationBetail,2);
            p.PrixBetail = (float)Math.Round(otpdto.PrixBetail,2);
            p.PrixIntervention = (float)Math.Round(otpdto.PrixIntervention,2);
            p.PrixService = (float)Math.Round(otpdto.PrixService,2);
            p.PrixTVA = (float)Math.Round(otpdto.PrixTVA,2);
            p.TypeInstallationFinal = otpdto.OffreRef.TypeInstallation;

            OffreBU obu = new();

            Offre o = new();
            if (p.IdOffre != null)
            {
                int i = (int)p.IdOffre;
                o = obu.GetById(i);
            }
            p.IdConditionsAnnulation = o.IdCondition;
            p.FrequenceIntervention = o.FrequenceIntervention;
            p.IdTypeTonte = o.FrequenceIntervention;

            return p;
        }

        public Prestation GetById(int id)
        {
            //Id should be > 0
            if (id <= 0)
            {
                throw new Exception("Id de prestation invalide");
            }
            PrestationDAO dao = new();
            return dao.GetById(id);
        }

        public List<PrestationDetail> GetAllByUtilisateurId(int id)
        {
            PrestationDAO pdao = new();
            List<PrestationDetail> pds = pdao.GetAllByUtilisateurId(id);

            return pds;
        }

        public PrestationDetail GetWithDetailsById(int id)
        {
            PrestationDAO pdao = new();
            PrestationDetail pd = pdao.GetWithDetailsById(id);
            NegociationBU nbu = new();

            pd.PrixInstallationCloture = (float)Math.Round(pd.PrixInstallationCloture, 2);
            pd.PrixInstallationBetail = (float)Math.Round(pd.PrixInstallationBetail, 2);
            pd.PrixBetail = (float)Math.Round(pd.PrixBetail, 2);
            pd.PrixIntervention = (float)Math.Round(pd.PrixIntervention, 2);
            pd.PrixService = (float)Math.Round(pd.PrixService, 2);
            pd.PrixTVA = (float)Math.Round(pd.PrixTVA, 2);
            pd.PrixConvenu = (float)Math.Round(pd.PrixConvenu, 2);
            pd.Negociations = nbu.GetAllWithDetailsByPrestationId(id);

            //ConditionAnnulationBU cabu = new();
            //pd.ConditionAnnulationRef = cabu.GetById(pd.IdConditionsAnnulation);
            return pd;
        }

        //Quand une négociation aboutit on crée une nouvelle prestation
        // Ou on update juste l'actuelle ?
        //public void InsertFrom

        public void Update(Prestation p)
        {
            PrestationDAO pdao = new();
            pdao.Update(p);
        }

        public void CancelPrestation(Prestation p)
        {
            p.DateAnnulation = DateTime.Now;
            Update(p);
        }

       // public PrestationDetail 
        public void ValidatePrestation(int id)
        {
            Prestation p = new();
            p.Id = id;
            p.DateValidation = DateTime.Now;
            PrestationDAO pdao = new();
            Update(p);
        }

        public List<PrestationDetail> GetAllEnCoursByUtilisateurId(int id)
        {
            PrestationDAO pdao = new();
            return pdao.GetAllEnCoursByUtilisateurId(id);
        }
    }
}
