using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class EvaluationDAO : DAO
    {
        public void Create(Evaluation e)
        {
            MySqlCommand cmd = CreerCommande();
            cmd.CommandText = @"INSERT INTO evaluation (id_utilisateur, id_prestation, note_evaluation, commentaire_evaluation)
                                VALUES (@id_utilisateur, @id_prestation, @note_evaluation, @commentaire_evaluation);";
            cmd.Parameters.Add(new MySqlParameter("@id_utilisateur", e.IdUtilisateurCible));
            cmd.Parameters.Add(new MySqlParameter("@id_prestation", e.IdPrestation));
            cmd.Parameters.Add(new MySqlParameter("@note_evaluation", e.Note));
            cmd.Parameters.Add(new MySqlParameter("@commentaire_evaluation", e.Commentaire));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public List<EvaluationDetail> GetAllWithDetailsByClientId(int id)
        {
            List<EvaluationDetail> evaluations = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT e.*, util.prenom 'prenom', u.id_utilisateur 'id_tier' ,u.prenom 'prenom_tier' FROM evaluation e
	                            INNER JOIN prestation p ON p.id_prestation = e.id_prestation
                                INNER JOIN utilisateur util ON util.id_utilisateur = e.id_utilisateur
	                            LEFT JOIN terrain te ON te.id_terrain = p.id_terrain
	                            LEFT JOIN troupeau tr ON tr.id_troupeau = p.id_troupeau
	                            INNER JOIN utilisateur u ON u.id_utilisateur = tr.id_utilisateur
	                            WHERE e.id_utilisateur = @id AND e.id_utilisateur = te.id_utilisateur;";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Evaluation e = DataReaderToEvaluation(dr);
                EvaluationDetail ed = new EvaluationDetail();
                ed.Id = e.Id;
                ed.IdPrestation = e.IdPrestation;
                ed.IdUtilisateurCible = e.IdUtilisateurCible;
                ed.Note = e.Note;
                ed.Commentaire = e.Commentaire;
                ed.IdTiers = dr.GetInt32("id_tier");
                ed.PrenomCible = dr.GetString("prenom");
                ed.PrenomTiers = dr.GetString("prenom_tier");
    
                evaluations.Add(ed);
                
            }

            cmd.Connection.Close();
            return evaluations;
        }

        public List<EvaluationDetail> GetAllWithDetailsByEleveurId(int id)
        {
            List<EvaluationDetail> evaluations = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT e.*, util.prenom 'prenom', u.id_utilisateur 'id_tier' ,u.prenom 'prenom_tier' FROM evaluation e
	                            INNER JOIN prestation p ON p.id_prestation = e.id_prestation
                                INNER JOIN utilisateur util ON util.id_utilisateur = e.id_utilisateur
	                            LEFT JOIN terrain te ON te.id_terrain = p.id_terrain
	                            LEFT JOIN troupeau tr ON tr.id_troupeau = p.id_troupeau
	                            INNER JOIN utilisateur u ON u.id_utilisateur = te.id_utilisateur
	                            WHERE e.id_utilisateur = @id AND e.id_utilisateur = tr.id_utilisateur;";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Evaluation e = DataReaderToEvaluation(dr);
                EvaluationDetail ed = new EvaluationDetail();
                ed.Id = e.Id;
                ed.IdPrestation = e.IdPrestation;
                ed.IdUtilisateurCible = e.IdUtilisateurCible;
                ed.Note = e.Note;
                ed.Commentaire = e.Commentaire;
                ed.IdTiers = dr.GetInt32("id_tier");
                ed.PrenomCible = dr.GetString("prenom");
                ed.PrenomTiers = dr.GetString("prenom_tier");

                evaluations.Add(ed);
            }

            cmd.Connection.Close();
            return evaluations;
        }

        public List<EvaluationDetail> GetAllWithDetailByOffreId(int idOffre)
        {
            List<EvaluationDetail> evaluations = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT e.*, o.id_offre, u.prenom, u2.id_utilisateur 'id_tier', u2.prenom 'prenom_tier' FROM evaluation e
                                INNER JOIN prestation p ON p.id_prestation = e.id_prestation
                                INNER JOIN offre o on o.id_offre = p.id_offre
                                INNER JOIN troupeau t ON t.id_troupeau = o.id_troupeau
                                INNER JOIN utilisateur u ON u.id_utilisateur = t.id_utilisateur
                                INNER JOIN terrain te ON te.id_terrain = p.id_terrain
                                INNER JOIN utilisateur u2 ON u2.id_utilisateur = te.id_utilisateur  
                                WHERE o.id_offre = @idOffre AND e.id_utilisateur = u.id_utilisateur";

            cmd.Parameters.Add(new MySqlParameter("@idOffre", idOffre));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Evaluation e = DataReaderToEvaluation(dr);
                EvaluationDetail ed = new EvaluationDetail();
                ed.Id = e.Id;
                ed.IdPrestation = e.IdPrestation;
                ed.IdUtilisateurCible = e.IdUtilisateurCible;
                ed.Note = e.Note;
                ed.Commentaire = e.Commentaire;
                ed.IdOffre = dr.GetInt32("id_offre");
                ed.PrenomCible = dr.GetString("prenom");
                ed.IdTiers = dr.GetInt32("id_tier");
                ed.PrenomTiers = dr.GetString("prenom_tier");

                evaluations.Add(ed);
            }

            cmd.Connection.Close();
            return evaluations;
        }
        
        private Evaluation DataReaderToEvaluation(MySqlDataReader dr)
        {
            Evaluation result = new Evaluation();
            result.Id = dr.GetInt32("id_evaluation");
            result.IdPrestation = dr.GetInt32("id_prestation");
            result.IdUtilisateurCible = dr.GetInt32("id_utilisateur");
            result.Note = dr.GetInt32("note_evaluation");
            result.Commentaire = dr.GetString("commentaire_evaluation");
            return result;
        }

    }
}
