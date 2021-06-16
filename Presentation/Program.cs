using Fr.EQL.AI109.Tontapat.Business;
using Fr.EQL.AI109.Tontapat.Dto;
using Fr.EQL.AI109.Tontapat.Model;
using System;
using System.Collections.Generic;

namespace Fr.EQL.AI109.Tontapat.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            /* GestionOffre go = new();
             *//*go.AddOffre(1, 1, 1, 1, "abc", true, DateTime.Now, DateTime.Now.AddDays(10),
                 DateTime.Now.AddDays(20), "kdjksjdk", 1.2f, 1.5f, 1.8f, 1.5f, 10, "jdkji", null);*//*
             //go.GetAll();
             Console.WriteLine(go.GetById(1));
             List<Offre> offres = go.GetAll();
             foreach(Offre o in offres)
             {
                 Console.WriteLine(o.DateDebut + " : " + o.NomOffre);
             }*/

            /*   GestionUtilisateur gu = new();
               gu.AddOffre();

            GestionUtilisateur gu = new();
            EvaluationBU bu = new();
            Console.WriteLine(bu.GetAllWithDetailByOffreAndUtilisateurId(1,2)); 
            
            OffreBU obu = new();
            RechercheOffreDto dto = new();
            dto.IdTerrain = 1;
            dto.DateDebut = new DateTime(2021,10,12,00,00,00);
            dto.IdEspece = null;
            dto.IdTypeTonte = null;
            dto.TypeInstallation = null;
            DateTime dateFin = new DateTime(2021, 11, 30, 00, 00, 00);
            List<OffreDetail> result = obu.RechercherOffre(dto, dateFin, 10, 30);
            foreach(OffreDetail od in result)
            {
                Console.WriteLine(od.DescriptionOffre);
            }
*/
        }
    }
}
