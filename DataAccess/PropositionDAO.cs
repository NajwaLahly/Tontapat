using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class PropositionDAO : DAO
    {
        public void Create(PropositionDetail p)
        {
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"INSERT INTO proposition
                                (id_negociation, id_utilisateur,date_creation, description,
                                date_debut_prestation, date_fin_prestation, prix_propose,
                                type_installation, id_terrain, id_type_tonte)
                               VALUES
                                (@id_negociation, @id_utilisateur,@date_creation, @description,
                                @date_debut_prestation, @date_fin_prestation, @prix_propose,
                                @type_installation, @id_terrain, @id_type_tonte)";

            cmd.Parameters.Add(new MySqlParameter("@id_negociation", p.IdNegociation));
            cmd.Parameters.Add(new MySqlParameter("@id_utilisateur", p.IdUtilisateur));
            cmd.Parameters.Add(new MySqlParameter("@date_creation", p.DateCreation));
            cmd.Parameters.Add(new MySqlParameter("@description", p.Description));
            cmd.Parameters.Add(new MySqlParameter("@date_debut_prestation", p.DateDebutPrestation));
            cmd.Parameters.Add(new MySqlParameter("@date_fin_prestation", p.DateFinPrestation));
            cmd.Parameters.Add(new MySqlParameter("@prix_propose", p.PrixPropose));
            cmd.Parameters.Add(new MySqlParameter("@type_installation", p.TypeInstallation));
            cmd.Parameters.Add(new MySqlParameter("@id_terrain", p.IdTerrain));
            cmd.Parameters.Add(new MySqlParameter("@id_type_tonte", p.IdTypeTonte));



            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }

        private Proposition DataReaderToProposition(MySqlDataReader dr)
        {
            Proposition result = new();
            result.Id = dr.GetInt32("id_proposition");
            result.IdNegociation = dr.GetInt32("id_negociation");
            result.IdUtilisateur = dr.GetInt32("id_utilisateur");
            result.DateCreation = dr.GetDateTime("date_creation");
            result.IdTerrain = dr.GetInt32("id_terrain");

            if (!dr.IsDBNull(dr.GetOrdinal("date_annulation")))
            {
                result.DateAnnulation = dr.GetDateTime("date_annulation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_validation")))
            {
                result.DateValidation = dr.GetDateTime("date_validation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_refus")))
            {
                result.DateRefus = dr.GetDateTime("date_refus");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("description")))
            {
                result.Description = dr.GetString("description");
            }

            if (!dr.IsDBNull(dr.GetOrdinal("date_debut_prestation")))
            {
                result.DateDebutPrestation = dr.GetDateTime("date_debut_prestation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_fin_prestation")))
            {
                result.DateFinPrestation = dr.GetDateTime("date_fin_prestation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("prix_propose")))
            {
                result.PrixPropose = dr.GetDouble("prix_propose");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("type_installation")))
            {
                result.TypeInstallation = dr.GetBoolean("type_installation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_type_tonte")))
            {
                result.IdTypeTonte = dr.GetInt32("id_type_tonte");
            }

            return result;
        }

        private PropositionDetail DataReaderToPropositionDetail(MySqlDataReader dr)
        {
            Proposition p = DataReaderToProposition(dr);
            PropositionDetail result = new();
            result.Id = p.Id;
            result.IdNegociation = p.IdNegociation;
            result.IdUtilisateur = p.IdUtilisateur;
            result.DateCreation = p.DateCreation;
            result.DateAnnulation = p.DateAnnulation;
            result.DateValidation = p.DateValidation;
            result.DateRefus = p.DateRefus;
            result.Description = p.Description;
            result.DateDebutPrestation = p.DateDebutPrestation;
            result.DateFinPrestation = p.DateFinPrestation;
            result.PrixPropose = p.PrixPropose;
            result.TypeInstallation = p.TypeInstallation;
            result.IdTerrain = p.IdTerrain;
            result.IdTypeTonte = p.IdTypeTonte;

            result.IdPrestation = dr.GetInt32("id_prestation");

            if (!dr.IsDBNull(dr.GetOrdinal("nom_terrain")))
            {
                result.NomTerrain = dr.GetString("nom_terrain");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("nom_type")))
            {
                result.NomTypeTonte = dr.GetString("nom_type");
            }

            return result;
        }
       
        public List<Proposition> GetAllByNegociationId(int id)
        {
            List<Proposition> result = new();

            MySqlCommand cmd = CreerCommande();
            cmd.CommandText = @"SELECT p.*, ne.id_prestation from proposition p
                                LEFT JOIN negociation ne ON ne.id_negociation = p.id_negociation
                                WHERE p.id_negociation = @id";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result.Add(DataReaderToProposition(dr));
            }
            cmd.Connection.Close();

            return result;
        }

        public PropositionDetail GetWithDetailsById(int id)
        {
            PropositionDetail result = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT p.*, ne.id_prestation, tt.nom_type, t.nom_terrain, t.id_terrain from proposition p
                                LEFT JOIN negociation ne ON ne.id_negociation = p.id_negociation
                                LEFT JOIN type_tonte tt ON p.id_type_tonte = tt.id_type
                                LEFT JOIN terrain t on p.id_terrain = t.id_terrain
                                WHERE id_proposition = @id";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToPropositionDetail(dr);
            }
            cmd.Connection.Close();

            return result;
        }

        public void Update(Proposition p)
        {
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"UPDATE proposition
                                SET date_annulation = @date_annulation,
                                date_validation = @date_validation,
                                date_refus = @date_refus
                                WHERE id_proposition = @id_proposition";

            cmd.Parameters.Add(new MySqlParameter("@date_annulation", p.DateAnnulation));
            cmd.Parameters.Add(new MySqlParameter("@date_validation", p.DateValidation));
            cmd.Parameters.Add(new MySqlParameter("@date_refus", p.DateRefus));
            cmd.Parameters.Add(new MySqlParameter("@id_proposition", p.Id));


            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }
    }
}