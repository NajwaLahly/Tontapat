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
                                (id_frequence, id_troupeau, id_type, id_prestation, id_tarif,
                                id_condition, nom_offre, date_ajout, date_debut, date_fin, description_offre,
                                type_installation, prix_km, prix_installation, prix_intervention, prix_bete_jour,
                                zone_couverture, adresse_offre, date_annulation_offre) 
                                VALUES (@id_frequence, @id_troupeau, @id_type, @id_prestation, @id_tarif,
                                @id_condition, @nom_offre, @date_ajout, @date_debut, @date_fin, @description_offre,
                                @type_installation, @prix_km, @prix_installation, @prix_intervention, @prix_bete_jour,
                                @zone_couverture, @adresse_offre, @date_annulation_offre)";

            cmd.Parameters.Add(new MySqlParameter("@id_frequence", o.IdFrequence));
            cmd.Parameters.Add(new MySqlParameter("@id_troupeau", o.IdTroupeau));
            cmd.Parameters.Add(new MySqlParameter("@id_type", o.IdTypeTonte));
            cmd.Parameters.Add(new MySqlParameter("@id_prestation", o.IdPrestation));
            cmd.Parameters.Add(new MySqlParameter("@id_tarif", o.IdTarif));
            cmd.Parameters.Add(new MySqlParameter("@id_condition", o.IdCondition));
            cmd.Parameters.Add(new MySqlParameter("@nom_offre", o.NomOffre));
            cmd.Parameters.Add(new MySqlParameter("@date_ajout", o.DateAjout));
            cmd.Parameters.Add(new MySqlParameter("@date_debut", o.DateDebut));
            cmd.Parameters.Add(new MySqlParameter("@date_fin", o.DateFin));
            cmd.Parameters.Add(new MySqlParameter("@description_offre", o.DescriptionOffre));
            cmd.Parameters.Add(new MySqlParameter("@type_installation", o.TypeInstallation));
            cmd.Parameters.Add(new MySqlParameter("@prix_km", o.PrixKm));
            cmd.Parameters.Add(new MySqlParameter("@prix_installation", o.PrixInstallation));
            cmd.Parameters.Add(new MySqlParameter("@prix_intervention", o.PrixIntervention));
            cmd.Parameters.Add(new MySqlParameter("@prix_bete_jour", o.PrixBeteJour));
            cmd.Parameters.Add(new MySqlParameter("@zone_couverture", o.ZoneCouverture));
            cmd.Parameters.Add(new MySqlParameter("@adresse_offre", o.AdresseOffre));
            cmd.Parameters.Add(new MySqlParameter("@date_annulation_offre", o.DateAnnulationOffre));
            #endregion

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            Console.WriteLine("requete executée");
            cmd.Connection.Close();
        }

        public List<Offre> GetAll()
        {
            List<Offre> result = new List<Offre>();

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
            result.IdTypeTonte = dr.GetInt32("id_type");
            result.IdPrestation = dr.GetInt32("id_prestation");
            result.IdTarif = dr.GetInt32("id_tarif");
            result.IdCondition = dr.GetInt32("id_condition");
            result.NomOffre = dr.GetString("nom_offre");
            result.DateAjout = dr.GetDateTime("date_ajout");
            result.DateDebut = dr.GetDateTime("date_debut");
            result.DateFin = dr.GetDateTime("date_fin");
            result.DescriptionOffre = dr.GetString("description_offre");
            result.TypeInstallation = dr.GetBoolean("type_installation");
            result.PrixKm = dr.GetFloat("prix_km");
            result.PrixInstallation = dr.GetFloat("prix_installation");
            result.PrixIntervention = dr.GetFloat("prix_intervention");
            result.PrixBeteJour = dr.GetFloat("prix_bete_jour");
            result.ZoneCouverture = dr.GetInt32("zone_couverture");
            result.AdresseOffre = dr.GetString("adresse_offre");
            result.DateAnnulationOffre = dr.GetDateTime("date_annulation_offre");

            return result;
        }

    }
}
