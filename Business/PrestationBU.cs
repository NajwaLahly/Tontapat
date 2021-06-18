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
            Console.WriteLine("Create Prestation exécuté");
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
            p.PrixConvenu = (float)otpdto.PrixTotal;
            p.TypeInstallationFinal = otpdto.OffreRef.TypeInstallation;
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

        }

    }
}
