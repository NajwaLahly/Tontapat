using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class PrestationDAO : DAO
    {
        public void Create(Prestation p)
        {
            // Create(Prestation) does not accept parameters related to Refus and Annulation such as
            // id_motif, Mot_id_motif(?), date_refus, description_refus, date_annulation and description_annulation
            // Refus and Annulation are to be set using Update ¯\_(ツ)_ /¯

            MySqlCommand cmd = CreerCommande();

            #region CONFIGURATION COMMANDE
            cmd.CommandText = @"INSERT INTO prestation 
                                (id_offre, id_terrain, id_troupeau, nb_betes, date_demande, date_validation,
                                prix_convenu, date_debut, date_fin, type_installation_final) 
                                VALUES (@id_offre, @id_terrain, @id_troupeau, @nb_betes, @date_demande, @date_validation,
                                @prix_convenu, @date_debut, @date_fin, @type_installation_final)";

            cmd.Parameters.Add(new MySqlParameter("@id_offre", p.IdOffre));
            cmd.Parameters.Add(new MySqlParameter("@id_terrain", p.IdTerrain));
            cmd.Parameters.Add(new MySqlParameter("@id_troupeau", p.IdTroupeau));
            cmd.Parameters.Add(new MySqlParameter("@nb_betes", p.NombreBetes));
            cmd.Parameters.Add(new MySqlParameter("@date_demande", p.DateDemande));
            cmd.Parameters.Add(new MySqlParameter("@date_validation", p.DateValidation));
            cmd.Parameters.Add(new MySqlParameter("@prix_convenu", p.PrixConvenu));
            cmd.Parameters.Add(new MySqlParameter("@date_debut", p.DateDebut));
            cmd.Parameters.Add(new MySqlParameter("@date_fin", p.DateFin));
            cmd.Parameters.Add(new MySqlParameter("@type_installation_final", p.TypeInstallationFinal));

            #endregion

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            Console.WriteLine("Prestation bien créée");
            cmd.Connection.Close();
        }

        private Prestation DataReaderToPrestation(MySqlDataReader dr)
        {
            Prestation result = new Prestation();
            result.Id = dr.GetInt32("id_prestation");

            result.IdTerrain = dr.GetInt32("id_terrain");
            result.IdTroupeau = dr.GetInt32("id_troupeau");
            result.NombreBetes = dr.GetInt32("nb_betes");
            result.PrixConvenu = dr.GetFloat("prix_convenu");
            result.DateDebut = dr.GetDateTime("date_debut");
            result.DateFin = dr.GetDateTime("date_fin");
            result.TypeInstallationFinal = dr.GetBoolean("type_installation_final");

            if (!dr.IsDBNull(dr.GetOrdinal("id_motif")))
            {
                result.IdMotifAnnulation = dr.GetInt32("id_motif");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_offre")))
            {
                result.IdOffre = dr.GetInt32("id_offre");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_demande")))
            {
                result.DateDemande = dr.GetDateTime("date_demande");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_validation")))
            {
                result.DateValidation = dr.GetDateTime("date_validation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_refus")))
            {
                result.DateRefus = dr.GetDateTime("date_refus");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_annulation")))
            {
                result.DateAnnulation = dr.GetDateTime("date_annulation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("description_refus")))
            {
                result.DescriptionRefus = dr.GetString("description_refus");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("description_annulation")))
            {
                result.DescriptionAnnulation = dr.GetString("description_annulation");
            }
            return result;
        }

        private PrestationDetail DataReaderToPrestationDetail(MySqlDataReader dr)
        {
            Prestation p = DataReaderToPrestation(dr);
            PrestationDetail pd = new();
            pd = (PrestationDetail)p;
            pd.Id = p.Id;
            pd.IdMotifAnnulation = p.IdMotifAnnulation;
            pd.IdTerrain = p.IdTerrain;
            pd.IdTroupeau = p.IdTroupeau;
            pd.IdOffre = p.IdOffre;
            pd.NombreBetes = p.NombreBetes;
            pd.IdMotifRefus = p.IdMotifRefus;
            pd.DateDemande = p.DateDemande;
            pd.DateValidation = p.DateValidation;
            pd.DateRefus = p.DateRefus;
            pd.DescriptionRefus = p.DescriptionRefus;
            pd.DateAnnulation = p.DateAnnulation;
            pd.DescriptionAnnulation = p.DescriptionAnnulation;
            pd.PrixConvenu = p.PrixConvenu;
            pd.DateDebut = p.DateDebut;
            pd.DateFin = p.DateFin;
            pd.TypeInstallationFinal = p.TypeInstallationFinal;

            pd.NomTerrain = dr.GetString("nom_terrain");
            pd.PrenomEleveur = dr.GetString("prenom_eleveur");
            pd.IdEspeceTroupeau = dr.GetInt32("id_troupeau");
            pd.NomRaceTroupeau = dr.GetString("nom_race");

            return pd;
        }

        public Prestation GetById(int id)
        {
            Prestation result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM prestation
                                WHERE id_prestation = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToPrestation(dr);
            }

            cmd.Connection.Close();

            return result;
        }

        public List<PrestationDetail> GetAllByUtilisateurId(int id)
        {
            List<PrestationDetail> result = null;

            MySqlCommand cmd = CreerCommande();

            //Inner Join ?
            cmd.CommandText = @"SELECT *
                                FROM prestation
                                WHERE id_offre = @id";
            cmd.Parameters.Add(new MySqlParameter("id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                result.Add(DataReaderToPrestationDetail(dr));
            }
            cmd.Connection.Close();

            return result;
        }
    }
}
