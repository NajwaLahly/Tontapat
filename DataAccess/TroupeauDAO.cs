using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class TroupeauDAO : DAO
    {
        public void Create(Troupeau t)
        {
            MySqlCommand cmd = CreerCommande();

            #region CONFIGURATION COMMANDE
            cmd.CommandText = @"INSERT INTO troupeau
                                (id_race, id_utilisateur, id_ville, nombre_betes, nom_troupeau,
                                description, adresse_voie, adresse_long, adresse_lat, date_ajout,
                                date_disponibilite, date_indisponibilite, photo1, photo2, photo3,
                                photo4, photo5, date_retrait_troup, divisibilite)
                                VALUES (@id_race, @id_utilisateur, @id_ville, @nombre_betes, @nom_troupeau,
                                @description, @adresse_voie, @adresse_long, @adresse_lat, @date_ajout,
                                @date_disponibilite, @date_indisponibilite, @photo1, @photo2, @photo3,
                                @photo4, @photo5, @date_retrait_troup, @divisibilite)";

            cmd.Parameters.Add(new MySqlParameter("@id_race", t.IdRace));
            cmd.Parameters.Add(new MySqlParameter("@id_utilisateur", t.IdUtilisateur));
            cmd.Parameters.Add(new MySqlParameter("@id_ville", t.IdVille));
            cmd.Parameters.Add(new MySqlParameter("@nombre_betes", t.NombreBetes));
            cmd.Parameters.Add(new MySqlParameter("@nom_troupeau", t.NomTroupeau));
            cmd.Parameters.Add(new MySqlParameter("@description", t.Description));
            cmd.Parameters.Add(new MySqlParameter("@adresse_voie", t.AdresseVoie));
            cmd.Parameters.Add(new MySqlParameter("@adresse_long", t.AdresseLong));
            cmd.Parameters.Add(new MySqlParameter("@adresse_lat", t.AdresseLat));
            cmd.Parameters.Add(new MySqlParameter("@date_ajout", t.DateAjout));
            cmd.Parameters.Add(new MySqlParameter("@date_disponibilite", t.DateDisponibilite));
            cmd.Parameters.Add(new MySqlParameter("@date_indisponibilite", t.DateIndisponibilite));
            cmd.Parameters.Add(new MySqlParameter("@photo1", t.Photo1));
            cmd.Parameters.Add(new MySqlParameter("@photo2", t.Photo2));
            cmd.Parameters.Add(new MySqlParameter("@photo3", t.Photo3));
            cmd.Parameters.Add(new MySqlParameter("@photo4", t.Photo4));
            cmd.Parameters.Add(new MySqlParameter("@photo5", t.Photo5));
            cmd.Parameters.Add(new MySqlParameter("@date_retrait_troup", t.DateRetrait));
            cmd.Parameters.Add(new MySqlParameter("@divisibilite", t.Divisibilite));

            #endregion

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            Console.WriteLine("Troupeau bien créé");
            cmd.Connection.Close();
        }

        private Troupeau DataReaderToTroupeau(MySqlDataReader dr)
        {
            Troupeau result = new();

            result.Id = dr.GetInt32("id_troupeau");
            result.IdRace = dr.GetInt32("id_race");
            result.IdUtilisateur = dr.GetInt32("id_utilisateur");
            result.IdVille = dr.GetInt32("id_ville");
            result.NombreBetes = dr.GetInt32("nb_betes");
            result.Description = dr.GetString("description");
            result.AdresseVoie = dr.GetString("adresse_voie");
            result.DateAjout = dr.GetDateTime("date_ajout");
            result.DateDisponibilite = dr.GetDateTime("date_disponibilite");
            result.Photo1 = dr.GetString("photo1");
            result.Photo2 = dr.GetString("photo2");
            result.Photo3 = dr.GetString("photo3");
            result.Photo4 = dr.GetString("photo4");
            result.Photo5 = dr.GetString("photo5");
            result.Divisibilite = dr.GetBoolean("divisibilite");

            if (!dr.IsDBNull(dr.GetOrdinal("adresse_long")))
            {
                result.AdresseLong = dr.GetFloat("adresse_long");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("adresse_lat")))
            {
                result.AdresseLat = dr.GetFloat("adresse_lat");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_indisponibilite")))
            {
                result.DateIndisponibilite = dr.GetDateTime("date_indisponibilite");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_retrait")))
            {
                result.DateRetrait = dr.GetDateTime("date_retrait_troup");
            }
            return result;
        }

        public Troupeau GetById(int id)
        {
            Troupeau result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM troupeau
                                WHERE id_troupeau = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToTroupeau(dr);
            }

            cmd.Connection.Close();

            return result;
        }

    }
}
