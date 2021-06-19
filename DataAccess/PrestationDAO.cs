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
                                (id_offre, id_terrain, id_troupeau, nb_betes, date_demande, id_type_tonte,
                                prix_convenu, prix_installation_cloture, prix_installation_betail, prix_betail, prix_intervention,
                                prix_service, prix_tva, date_debut, date_fin, type_installation_final, frequence_intervention, id_condition) 
                                VALUES
                                (@id_offre, @id_terrain, @id_troupeau, @nb_betes, @date_demande, @id_type_tonte,
                                @prix_convenu, @prix_installation_cloture, @prix_installation_betail, @prix_betail, @prix_intervention,
                                @prix_service, @prix_tva, @date_debut, @date_fin, @type_installation_final, @frequence_intervention, @id_condition)";

            cmd.Parameters.Add(new MySqlParameter("@id_offre", p.IdOffre));
            cmd.Parameters.Add(new MySqlParameter("@id_terrain", p.IdTerrain));
            cmd.Parameters.Add(new MySqlParameter("@id_troupeau", p.IdTroupeau));
            cmd.Parameters.Add(new MySqlParameter("@nb_betes", p.NombreBetes));
            cmd.Parameters.Add(new MySqlParameter("@date_demande", p.DateDemande));
            cmd.Parameters.Add(new MySqlParameter("@prix_convenu", p.PrixConvenu));
            cmd.Parameters.Add(new MySqlParameter("@prix_installation_cloture", p.PrixInstallationCloture));
            cmd.Parameters.Add(new MySqlParameter("@prix_installation_betail", p.PrixInstallationBetail));
            cmd.Parameters.Add(new MySqlParameter("@prix_betail", p.PrixBetail));
            cmd.Parameters.Add(new MySqlParameter("@prix_intervention", p.PrixIntervention));
            cmd.Parameters.Add(new MySqlParameter("@prix_service", p.PrixService));
            cmd.Parameters.Add(new MySqlParameter("@prix_tva", p.PrixTVA));
            cmd.Parameters.Add(new MySqlParameter("@frequence_intervention", p.FrequenceIntervention));
            cmd.Parameters.Add(new MySqlParameter("@id_condition", p.IdConditionsAnnulation));
            cmd.Parameters.Add(new MySqlParameter("@id_type_tonte", p.IdTypeTonte));

            cmd.Parameters.Add(new MySqlParameter("@date_debut", p.DateDebut));
            cmd.Parameters.Add(new MySqlParameter("@date_fin", p.DateFin));
            cmd.Parameters.Add(new MySqlParameter("@type_installation_final", p.TypeInstallationFinal));

            #endregion

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }

        private Prestation DataReaderToPrestation(MySqlDataReader dr)
        {
            Prestation result = new();
            result.Id = dr.GetInt32("id_prestation");
            result.IdTerrain = dr.GetInt32("id_terrain");
            result.IdTroupeau = dr.GetInt32("id_troupeau");
            result.IdTypeTonte = dr.GetInt32("id_type_tonte");
            result.NombreBetes = dr.GetInt32("nb_betes");
            result.PrixConvenu = dr.GetFloat("prix_convenu");
            result.PrixInstallationCloture = dr.GetFloat("prix_installation_cloture");
            result.PrixInstallationBetail = dr.GetFloat("prix_installation_betail");
            result.PrixBetail = dr.GetFloat("prix_betail");
            result.PrixIntervention = dr.GetFloat("prix_intervention");
            result.PrixService = dr.GetFloat("prix_service");
            result.PrixTVA = dr.GetFloat("prix_tva");

            result.DateDebut = dr.GetDateTime("date_debut");
            result.DateFin = dr.GetDateTime("date_fin");
            result.TypeInstallationFinal = dr.GetBoolean("type_installation_final");
            result.FrequenceIntervention = dr.GetInt32("frequence_intervention");
            result.IdConditionsAnnulation = dr.GetInt32("id_condition");

            if (!dr.IsDBNull(dr.GetOrdinal("id_ancienne")))
            {
                result.IdAncienne = dr.GetInt32("id_ancienne");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_motif_refus")))
            {
                result.IdMotifRefus = dr.GetInt32("id_motif_refus");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_motif_annulation")))
            {
                result.IdMotifAnnulation = dr.GetInt32("id_motif_annulation");
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
            pd.Id = p.Id;
            pd.IdMotifAnnulation = p.IdMotifAnnulation;
            pd.IdTerrain = p.IdTerrain;
            pd.IdTroupeau = p.IdTroupeau;
            pd.IdTypeTonte = p.IdTypeTonte;
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
            pd.PrixInstallationCloture = p.PrixInstallationCloture;
            pd.PrixInstallationBetail = p.PrixInstallationBetail;
            pd.PrixBetail = p.PrixBetail;
            pd.PrixIntervention = p.PrixIntervention;
            pd.PrixService = p.PrixService;
            pd.PrixTVA = p.PrixTVA;
            pd.FrequenceIntervention = p.FrequenceIntervention;
            pd.DateDebut = p.DateDebut;
            pd.DateFin = p.DateFin;
            pd.TypeInstallationFinal = p.TypeInstallationFinal;
            pd.IdConditionsAnnulation = p.IdConditionsAnnulation;

            pd.NomTerrain = dr.GetString("nom_terrain");
            pd.PrenomEleveur = dr.GetString("prenom");
            pd.IdEspeceTroupeau = dr.GetInt32("id_troupeau");
            pd.NomRaceTroupeau = dr.GetString("nom_race");
            pd.NomTypeTonte = dr.GetString("nom_type");
            pd.IdEleveur = dr.GetInt32("id_utilisateur");


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
            List<PrestationDetail> result = new();

            MySqlCommand cmd = CreerCommande();

            //Inner Join ?
            cmd.CommandText = @"SELECT p.*,t.nom_terrain,u2.prenom,u2.id_utilisateur,tr.id_troupeau,r.nom_race,tt.nom_type FROM prestation p
                                LEFT JOIN terrain t on p.id_terrain = t.id_terrain
                                LEFT JOIN utilisateur u on t.id_utilisateur = u.id_utilisateur
                                LEFT JOIN troupeau tr on tr.id_troupeau = p.id_troupeau
                                LEFT JOIN utilisateur u2 on tr.id_utilisateur = u2.id_utilisateur
                                LEFT JOIN race r on tr.id_race = r.id_race
                                LEFT JOIN type_tonte tt on tt.id_type = p.id_type_tonte
                                WHERE u.id_utilisateur = @id";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result.Add(DataReaderToPrestationDetail(dr));
            }
            cmd.Connection.Close();

            return result;
        }

        public PrestationDetail GetWithDetailsById(int id)
        {
            PrestationDetail result = new();

            MySqlCommand cmd = CreerCommande();

            //Inner Join ?
            cmd.CommandText = @"SELECT p.*,t.nom_terrain,u2.prenom,u2.id_utilisateur,tr.id_troupeau,r.nom_race,tt.nom_type FROM prestation p
                                LEFT JOIN terrain t on p.id_terrain = t.id_terrain
                                LEFT JOIN utilisateur u on t.id_utilisateur = u.id_utilisateur
                                LEFT JOIN troupeau tr on tr.id_troupeau = p.id_troupeau
                                LEFT JOIN utilisateur u2 on tr.id_utilisateur = u2.id_utilisateur
                                LEFT JOIN race r on tr.id_race = r.id_race
                                LEFT JOIN type_tonte tt on tt.id_type = p.id_type_tonte
                                WHERE p.id_prestation = @id;";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToPrestationDetail(dr);
            }
            cmd.Connection.Close();

            return result;
        }

        public void Update(Prestation p)
        {
            MySqlCommand cmd = CreerCommande();

            //Tout ce qui peut normalement être modifié dans l'évolution normale de la prestation
            // (validation ou refus, annulation) en premier,

            //Les modifications portant sur la négociation en deuxième
            cmd.CommandText = @"UPDATE prestation
                                SET id_motif_annulation = @id_motif,
                                id_motif_refus = @date_validation
                                description_annulation = @date_validation
                                description_refus = @date_validation
                                date_annulation = @date_validation
                                date_refus = @date_validation

                                id_terrain = @id_terrain
                                prix_convenu = @prix_convenu
                                prix_installation_cloture = @prix_installation_cloture
                                prix_installation_betail = @prix_installation_betail
                                prix_betail = @prix_betail
                                prix_service = @prix_service
                                prix_tva = @prix_tva
                                date_debut = @date_debut
                                date_fin = @date_fin
                                nb_betes = @nb_betes
                                type_installation_final = @type_installation_final

                                WHERE id_prestation = @id_prestation";

            cmd.Parameters.Add(new MySqlParameter("@date_annulation", p.DateAnnulation));
            cmd.Parameters.Add(new MySqlParameter("@date_validation", p.DateValidation));
            cmd.Parameters.Add(new MySqlParameter("@date_refus", p.DateRefus));
            cmd.Parameters.Add(new MySqlParameter("@id_prestation", p.Id));

            cmd.Parameters.Add(new MySqlParameter("@id_terrain", p.IdTerrain));
            cmd.Parameters.Add(new MySqlParameter("@prix_convenu", p.PrixConvenu));
            cmd.Parameters.Add(new MySqlParameter("@prix_installation_cloture", p.PrixInstallationCloture));
            cmd.Parameters.Add(new MySqlParameter("@prix_installation_betail", p.PrixInstallationBetail));
            cmd.Parameters.Add(new MySqlParameter("@prix_betail", p.PrixBetail));
            cmd.Parameters.Add(new MySqlParameter("@prix_service", p.PrixService));
            cmd.Parameters.Add(new MySqlParameter("@prix_tva", p.PrixTVA));
            cmd.Parameters.Add(new MySqlParameter("@date_debut", p.DateDebut));
            cmd.Parameters.Add(new MySqlParameter("@date_fin", p.DateFin));
            cmd.Parameters.Add(new MySqlParameter("@nb_betes", p.NombreBetes));
            cmd.Parameters.Add(new MySqlParameter("@type_installation_final", p.TypeInstallationFinal));


            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }
    }
}
