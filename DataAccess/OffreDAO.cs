using Fr.EQL.AI109.Tontapat.Dto;
using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class OffreDAO : DAO
    {
        public void Create(Offre o)
        {
            MySqlCommand cmd = CreerCommande();
            #region config command
            cmd.CommandText = @"INSERT INTO offre 
                                (id_frequence, id_troupeau, id_type, 
                                id_condition, nom_offre, date_ajout, date_debut, date_fin, description_offre,
                                type_installation, prix_km, coef_installation, coef_intervention, prix_bete_jour,
                                zone_couverture, adresse_offre, date_annulation_offre) 
                                VALUES (@id_frequence, @id_troupeau, @id_type, 
                                @id_condition, @nom_offre, @date_ajout, @date_debut, @date_fin, @description_offre,
                                @type_installation, @prix_km, @coef_installation, @coef_intervention, @prix_bete_jour,
                                @zone_couverture, @adresse_offre, @date_annulation_offre)";

            cmd.Parameters.Add(new MySqlParameter("@id_frequence", o.IdFrequence));
            cmd.Parameters.Add(new MySqlParameter("@id_troupeau", o.IdTroupeau));
            cmd.Parameters.Add(new MySqlParameter("@id_type", o.IdTypeTonte));
            cmd.Parameters.Add(new MySqlParameter("@id_condition", o.IdCondition));
            cmd.Parameters.Add(new MySqlParameter("@nom_offre", o.NomOffre));
            cmd.Parameters.Add(new MySqlParameter("@date_ajout", o.DateAjout));
            cmd.Parameters.Add(new MySqlParameter("@date_debut", o.DateDebut));
            cmd.Parameters.Add(new MySqlParameter("@date_fin", o.DateFin));
            cmd.Parameters.Add(new MySqlParameter("@description_offre", o.DescriptionOffre));
            cmd.Parameters.Add(new MySqlParameter("@type_installation", o.TypeInstallation));
            cmd.Parameters.Add(new MySqlParameter("@prix_km", o.PrixKm));
            cmd.Parameters.Add(new MySqlParameter("@coef_installation", o.CoefInstallation));
            cmd.Parameters.Add(new MySqlParameter("@coef_intervention", o.CoefIntervention));
            cmd.Parameters.Add(new MySqlParameter("@prix_bete_jour", o.PrixBeteJour));
            cmd.Parameters.Add(new MySqlParameter("@zone_couverture", o.ZoneCouverture));
            cmd.Parameters.Add(new MySqlParameter("@adresse_offre", o.AdresseOffre));
            cmd.Parameters.Add(new MySqlParameter("@date_annulation_offre", o.DateAnnulationOffre));
            #endregion

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }

        public List<OffreDetail> GetSearchResultsWithDetailsByParams(RechercheOffreDto rod)
        {
            List<OffreDetail> result = new List<OffreDetail>();

            MySqlCommand cmd = CreerCommande();


            /* string commandText = @"SELECT o.*,r.nom_race, e.nom_espece, tt.nom_type, u.nom, u.prenom,
                                 v.nom_ville, c.nom_condition, u.id_utilisateur, e.id_espece, d.distance, tr.nombre_betes FROM offre o
                                 INNER JOIN troupeau tr ON o.id_troupeau = tr.id_troupeau
                                 INNER JOIN race r ON r.id_race = tr.id_race
                                 LEFT JOIN type_tonte tt ON tt.id_type = o.id_type
                                 LEFT JOIN espece e ON r.id_espece = e.id_espece
                                 LEFT JOIN utilisateur u ON u.id_utilisateur = tr.id_utilisateur
                                 LEFT JOIN ville v ON v.id_ville = tr.id_ville
                                 LEFT JOIN condition_annulation c ON c.id_condition = o.id_condition
                                 INNER JOIN terrain te ON te.id_terrain = @idTerrain
                                 INNER JOIN distance_villes d ON 
                                 (d.id_ville = id_terrain AND d.vil_id_ville = tr.id_ville)
                                 OR (d.id_ville = tr.id_ville AND d.vil_id_ville = id_terrain)

                                 WHERE d.distance <= o.zone_couverture
                                 and o.date_debut <= @dateDebut
                                 and (o.date_fin >= @dateFinMin or o.date_fin <= @dateFinMax)
                                 and ((tr.nombre_betes <= @nbreBetesMax and tr.nombre_betes >= @nbreBetesMin)
                                 or (tr.nombre_betes > @nbreBetesMax and tr.divisibilite = true))";*/

            string commandText = @"SELECT o.*,r.nom_race, e.nom_espece, tt.nom_type, u.nom, u.prenom, tr.divisibilite, tr.id_ville,
                                v.nom_ville, c.nom_condition, u.id_utilisateur, e.id_espece, d.distance, tr.nombre_betes FROM offre o
                                INNER JOIN troupeau tr ON o.id_troupeau = tr.id_troupeau
                                INNER JOIN race r ON r.id_race = tr.id_race
                                LEFT JOIN type_tonte tt ON tt.id_type = o.id_type
                                LEFT JOIN espece e ON r.id_espece = e.id_espece
                                LEFT JOIN utilisateur u ON u.id_utilisateur = tr.id_utilisateur
                                LEFT JOIN ville v ON v.id_ville = tr.id_ville
                                LEFT JOIN condition_annulation c ON c.id_condition = o.id_condition
                                INNER JOIN terrain te ON te.id_terrain = @idTerrain
                                INNER JOIN distance_villes d ON 
                                (d.id_ville = id_terrain AND d.vil_id_ville = tr.id_ville)
                                OR (d.id_ville = tr.id_ville AND d.vil_id_ville = id_terrain)

                                WHERE d.distance <= o.zone_couverture
                                and o.date_debut <= @dateDebut
                                and (o.date_fin >= @dateFin)
                                and ((tr.nombre_betes <= @nbBetes + 5 and tr.nombre_betes >= @nbBetes - 5)
                                or (tr.nombre_betes > @nbBetes and tr.divisibilite = true))";

            if (rod.IdEspece != null)
                commandText += " and r.id_espece = @idEspece";
            if (rod.IdTypeTonte != 4)
                commandText += " and (o.id_type = @idType or o.id_type = 4)";
            if(rod.TypeInstallation != null)
                commandText += " and o.type_installation = @typeInstall";

            cmd.CommandText = commandText;

            cmd.Parameters.Add(new MySqlParameter("@idTerrain", rod.IdTerrain));
            cmd.Parameters.Add(new MySqlParameter("@dateDebut", rod.DateDebut));
            cmd.Parameters.Add(new MySqlParameter("@dateFin", rod.DateFin));
            /*cmd.Parameters.Add(new MySqlParameter("@dateFinMax", rod.DateFinMax));
            cmd.Parameters.Add(new MySqlParameter("@nbreBetesMin", rod.NbBetesMin));*/
            cmd.Parameters.Add(new MySqlParameter("@nbBetes", rod.NbBetes));
            cmd.Parameters.Add(new MySqlParameter("@idEspece", rod.IdEspece));
            cmd.Parameters.Add(new MySqlParameter("@idType", rod.IdTypeTonte));
            cmd.Parameters.Add(new MySqlParameter("@typeInstall", rod.TypeInstallation));


            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Offre o = DataReaderToOffre(dr);

                OffreDetail od = new OffreDetail();

                od.Id = o.Id;
                od.IdFrequence = o.IdFrequence;
                od.IdTroupeau = o.IdTroupeau;
                
                od.IdTypeTonte = o.IdTypeTonte;
                od.NomOffre = o.NomOffre;
                od.DateAjout = o.DateAjout;
                od.DateDebut = o.DateAjout;
                od.DateFin = o.DateFin;
                od.DescriptionOffre = o.DescriptionOffre;
                od.TypeInstallation = o.TypeInstallation;
                od.PrixKm = o.PrixKm;
                od.CoefInstallation = o.CoefInstallation;
                od.CoefIntervention = o.CoefIntervention;
                od.PrixBeteJour = o.PrixBeteJour;
                od.ZoneCouverture = o.ZoneCouverture;
                od.AdresseOffre = o.AdresseOffre;

                if (!dr.IsDBNull(dr.GetOrdinal("nom_type")))
                {
                    od.TypeTonte = dr.GetString("nom_type");
                }
                
                od.PrenomEleveur = dr.GetString("prenom");
                od.VilleTroupeau = dr.GetString("nom_ville");
                od.Race = dr.GetString("nom_race");
                od.Condition = dr.GetString("nom_condition");
                od.IdUtilisateur = dr.GetInt32("id_utilisateur");
                od.IdEspece = dr.GetInt32("id_espece");
                od.NbBetes = dr.GetInt32("nombre_betes");
                od.Divisibilite = dr.GetBoolean("divisibilite");
                od.IdVilleTroupeau = dr.GetInt32("id_ville");

                EvaluationDAO edao = new();
                od.NbEvaluations = edao.GetAllWithDetailsByOffreId(od.Id).Count;
                od.Moyenne = GetAverageByOffreId(od.Id);
                result.Add(od);
            }

            cmd.Connection.Close();

            return result;
        }
    
        public List<Offre> GetAll()
        {
            List<Offre> result = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = "SELECT * FROM offre";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Offre o = DataReaderToOffre(dr);

                result.Add(o);
            }

            cmd.Connection.Close();

            return result;
        }

        private Offre DataReaderToOffre(MySqlDataReader dr)
        {
            Offre result = new Offre();
            result.Id = dr.GetInt32("id_offre");
            result.IdFrequence = dr.GetInt32("id_frequence");
            result.IdTroupeau = dr.GetInt32("id_troupeau");
            
            result.IdCondition = dr.GetInt32("id_condition");
            result.NomOffre = dr.GetString("nom_offre");
            result.DateAjout = dr.GetDateTime("date_ajout");
            result.DateDebut = dr.GetDateTime("date_debut");
            result.DateFin = dr.GetDateTime("date_fin");
            result.DescriptionOffre = dr.GetString("description_offre");
            result.TypeInstallation = dr.GetBoolean("type_installation");
            result.PrixKm = dr.GetFloat("prix_km");
            result.CoefInstallation = dr.GetFloat("coef_installation");
            result.CoefIntervention = dr.GetFloat("coef_intervention");
            result.PrixBeteJour = dr.GetFloat("prix_bete_jour");
            result.ZoneCouverture = dr.GetInt32("zone_couverture");
            result.AdresseOffre = dr.GetString("adresse_offre");

            if (!dr.IsDBNull(dr.GetOrdinal("date_annulation_offre")))
            {
                result.DateAnnulationOffre = dr.GetDateTime("date_annulation_offre");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_type")))
            {
                result.IdTypeTonte = dr.GetInt32("id_type");
            }

            return result;
        }

        public Offre GetById(int id)
        {
            Offre result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM offre
                                WHERE id_offre = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToOffre(dr);
            }

            cmd.Connection.Close();

            return result;
        }

        public List<OffreDetail> GetAllWithDetails()
        {
            List<OffreDetail> result = new List<OffreDetail>();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT o.*,r.nom_race, t.id_ville, t.divisibilite, e.nom_espece, tt.nom_type, u.nom, u.prenom, v.nom_ville, c.nom_condition, u.id_utilisateur, e.id_espece, t.nombre_betes
                                FROM offre o
                                LEFT JOIN type_tonte tt ON tt.id_type = o.id_type
                                LEFT JOIN troupeau t ON o.id_troupeau = t.id_troupeau
                                LEFT JOIN race r ON t.id_race = r.id_race
                                LEFT JOIN espece e ON r.id_espece = e.id_espece
                                LEFT JOIN utilisateur u ON u.id_utilisateur = t.id_utilisateur
                                LEFT JOIN ville v ON v.id_ville = t.id_ville
                                LEFT JOIN condition_annulation c ON c.id_condition= o.id_condition
                                ORDER BY date_debut ASC;";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Offre o = DataReaderToOffre(dr);

                OffreDetail od = new OffreDetail();

                od.Id = o.Id;
                od.IdFrequence = o.IdFrequence;
                od.IdTroupeau = o.IdTroupeau;
                od.IdTypeTonte = o.IdTypeTonte;
                od.NomOffre = o.NomOffre;
                od.DateAjout = o.DateAjout;
                od.DateDebut = o.DateAjout;
                od.DateFin = o.DateFin;
                od.DescriptionOffre = o.DescriptionOffre;
                od.TypeInstallation = o.TypeInstallation;
                od.PrixKm = o.PrixKm;
                od.CoefInstallation = o.CoefInstallation;
                od.CoefIntervention = o.CoefIntervention;
                od.PrixBeteJour = o.PrixBeteJour;
                od.ZoneCouverture = o.ZoneCouverture;
                od.AdresseOffre = o.AdresseOffre;
                if (!dr.IsDBNull(dr.GetOrdinal("nom_type")))
                {
                    od.TypeTonte = dr.GetString("nom_type");
                }
               
                od.PrenomEleveur = dr.GetString("prenom");
                od.VilleTroupeau = dr.GetString("nom_ville");
                od.Divisibilite = dr.GetBoolean("divisibilite");
                od.IdVilleTroupeau = dr.GetInt32("id_ville");

                od.Race = dr.GetString("nom_race");
                od.Condition = dr.GetString("nom_condition");
                od.IdUtilisateur = dr.GetInt32("id_utilisateur");
                od.IdEspece = dr.GetInt32("id_espece");
                od.NbBetes = dr.GetInt32("nombre_betes");
                od.Moyenne = GetAverageByOffreId(od.Id);
                result.Add(od);
            }

            cmd.Connection.Close();

            return result;
        }

        private OffreDetail DataReadertoOffreDetail(MySqlDataReader dr)
        {
            Offre o = DataReaderToOffre(dr);
            OffreDetail od = new();
            return od;
        }

        public List<OffreDetail> GetAllWithDetailsByUtilisateurId(int id)
        {
            List<OffreDetail> result = new List<OffreDetail>();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT o.*,r.nom_race, t.id_ville, t.divisibilite, e.nom_espece, e.id_espece, tt.nom_type, u.nom, u.prenom, v.nom_ville, c.nom_condition, u.id_utilisateur, t.nombre_betes 
                                FROM offre o
                                LEFT JOIN type_tonte tt ON tt.id_type = o.id_type
                                LEFT JOIN troupeau t ON o.id_troupeau = t.id_troupeau
                                LEFT JOIN race r ON t.id_race = r.id_race
                                LEFT JOIN espece e ON r.id_espece = e.id_espece
                                LEFT JOIN ville v ON v.id_ville = t.id_ville
                                LEFT JOIN condition_annulation c ON c.id_condition= o.id_condition
                                LEFT JOIN utilisateur u on u.id_utilisateur = t.id_utilisateur where u.id_utilisateur= @id;";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Offre o = DataReaderToOffre(dr);

                OffreDetail od = new OffreDetail();

                od.Id = o.Id;
                od.IdFrequence = o.IdFrequence;
                od.IdTroupeau = o.IdTroupeau;
                od.IdTypeTonte = o.IdTypeTonte;
                od.NomOffre = o.NomOffre;
                od.DateAjout = o.DateAjout;
                od.DateDebut = o.DateAjout;
                od.DateFin = o.DateFin;
                od.DescriptionOffre = o.DescriptionOffre;
                od.TypeInstallation = o.TypeInstallation;
                od.PrixKm = o.PrixKm;
                od.CoefInstallation = o.CoefInstallation;
                od.CoefIntervention = o.CoefIntervention;
                od.PrixBeteJour = o.PrixBeteJour;
                od.ZoneCouverture = o.ZoneCouverture;
                od.AdresseOffre = o.AdresseOffre;
                od.TypeTonte = dr.GetString("nom_type");
                od.PrenomEleveur = dr.GetString("prenom");
                od.VilleTroupeau = dr.GetString("nom_ville");
                od.Race = dr.GetString("nom_race");
                od.Condition = dr.GetString("nom_condition");
                od.IdUtilisateur = dr.GetInt32("id_utilisateur");
                od.Divisibilite = dr.GetBoolean("divisibilite");
                od.IdVilleTroupeau = dr.GetInt32("id_ville");

                od.IdEspece = dr.GetInt32("id_espece");
                od.Moyenne = GetAverageByOffreId(od.Id);
                od.NbBetes = dr.GetInt32("nombre_betes");
                result.Add(od);
            }

            cmd.Connection.Close();

            return result;
        }

        public  OffreDetail GetWithDetailsById(int id)
        {
            OffreDetail od = new OffreDetail();
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT o.*,r.nom_race, t.id_ville, t.divisibilite, e.nom_espece, tt.nom_type, u.nom, u.prenom, v.nom_ville, c.nom_condition, u.id_utilisateur, e.id_espece, t.nombre_betes
                                FROM offre o
                                LEFT JOIN type_tonte tt ON tt.id_type = o.id_type
                                LEFT JOIN troupeau t ON o.id_troupeau = t.id_troupeau
                                LEFT JOIN race r ON t.id_race = r.id_race
                                LEFT JOIN espece e ON r.id_espece = e.id_espece
                                LEFT JOIN utilisateur u ON u.id_utilisateur = t.id_utilisateur
                                LEFT JOIN ville v ON v.id_ville = t.id_ville
                                LEFT JOIN condition_annulation c ON c.id_condition= o.id_condition
                                WHERE o.id_offre = @id";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Offre o = DataReaderToOffre(dr);

                od.Id = o.Id;
                od.IdFrequence = o.IdFrequence;
                od.IdTroupeau = o.IdTroupeau;
                od.IdTypeTonte = o.IdTypeTonte;
                od.NomOffre = o.NomOffre;
                od.DateAjout = o.DateAjout;
                od.DateDebut = o.DateAjout;
                od.DateFin = o.DateFin;
                od.DescriptionOffre = o.DescriptionOffre;
                od.TypeInstallation = o.TypeInstallation;
                od.PrixKm = o.PrixKm;
                od.CoefInstallation = o.CoefInstallation;
                od.CoefIntervention = o.CoefIntervention;
                od.PrixBeteJour = o.PrixBeteJour;
                od.ZoneCouverture = o.ZoneCouverture;
                od.AdresseOffre = o.AdresseOffre;
                od.TypeTonte = dr.GetString("nom_type");
                od.PrenomEleveur = dr.GetString("prenom");
                od.VilleTroupeau = dr.GetString("nom_ville");
                od.Race = dr.GetString("nom_race");
                od.Espece = dr.GetString("nom_espece");
                od.Condition = dr.GetString("nom_condition");
                od.IdUtilisateur = dr.GetInt32("id_utilisateur");
                od.IdEspece = dr.GetInt32("id_espece");
                od.Moyenne = GetAverageByOffreId(od.Id);
                od.NbBetes = dr.GetInt32("nombre_betes");
                EvaluationDAO edao = new();
                od.NbEvaluations = edao.GetAllWithDetailsByOffreId(od.Id).Count;
                od.Divisibilite = dr.GetBoolean("divisibilite");
                od.IdVilleTroupeau = dr.GetInt32("id_ville");

            }

            cmd.Connection.Close();

            return od;
        }

        public double GetAverageByOffreId(int id)
        {
            double result = new();
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT AVG(note_evaluation) 'average' FROM evaluation e
		                        INNER JOIN prestation p ON p.id_prestation = e.id_prestation
                                INNER JOIN offre o ON o.id_offre = p.id_offre
                                INNER JOIN troupeau t ON t.id_troupeau = o.id_troupeau
                                WHERE o.id_offre = 2 and e.id_utilisateur = t.id_utilisateur;";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (!dr.IsDBNull(dr.GetOrdinal("average")))
                {
                    result = dr.GetDouble("average");
                }

            }
            else
            {
                result = -1;
            }

            cmd.Connection.Close();
            return result;
        }

        


    }
}
