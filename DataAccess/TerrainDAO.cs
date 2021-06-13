using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class TerrainDAO : DAO
    {
        public void Create(Terrain t)
        {
            MySqlCommand cmd = CreerCommande();

            #region CONFIGURATION COMMANDE
            cmd.CommandText = @"INSERT INTO terrain
                                (id_ville, id_cloture, id_utilisateur, id_type_terrain, nom_terrain,
                                superficie_terrain, description, date_ajout, acces_public, adresse_long,
                                adresse_lat, adresse_voie, photo1, photo2, photo3, photo4, photo5,
                                presence_camera, presence_service_securite)
                                VALUES (@id_ville, @id_cloture, @id_utilisateur, @id_type_terrain, @nom_terrain,
                                @superficie_terrain, @description, @date_ajout, @acces_public, @adresse_long,
                                @adresse_lat, @adresse_voie, @photo1, @photo2, @photo3, @photo4, @photo5,
                                @presence_camera, @presence_service_securite)";

            cmd.Parameters.Add(new MySqlParameter("@id_ville", t.IdVille));
            cmd.Parameters.Add(new MySqlParameter("@id_cloture", t.IdCloture));
            cmd.Parameters.Add(new MySqlParameter("@id_utilisateur", t.IdUtilisateur));
            cmd.Parameters.Add(new MySqlParameter("@id_type_terrain", t.IdTypeTerrain));
            cmd.Parameters.Add(new MySqlParameter("@nom_terrain", t.Nom));
            cmd.Parameters.Add(new MySqlParameter("@superficie_terrain", t.Superficie));
            cmd.Parameters.Add(new MySqlParameter("@description", t.Description));
            cmd.Parameters.Add(new MySqlParameter("@date_ajout", t.DateAjout));
            cmd.Parameters.Add(new MySqlParameter("@acces_public", t.AccesPublic));
            cmd.Parameters.Add(new MySqlParameter("@adresse_long", t.AdresseLong));
            cmd.Parameters.Add(new MySqlParameter("@adresse_lat", t.AdresseLat));
            cmd.Parameters.Add(new MySqlParameter("@adresse_voie", t.AdresseVoie));
            cmd.Parameters.Add(new MySqlParameter("@photo1", t.Photo1));
            cmd.Parameters.Add(new MySqlParameter("@photo2", t.Photo2));
            cmd.Parameters.Add(new MySqlParameter("@photo3", t.Photo3));
            cmd.Parameters.Add(new MySqlParameter("@photo4", t.Photo4));
            cmd.Parameters.Add(new MySqlParameter("@photo5", t.Photo5));
            cmd.Parameters.Add(new MySqlParameter("@presence_camera", t.PresenceCamera));
            cmd.Parameters.Add(new MySqlParameter("@presence_service_securite", t.ServiceSecurite));

            #endregion

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            Console.WriteLine("Terrain bien créé");
            cmd.Connection.Close();
        }

        private Terrain DataReaderToTerrain(MySqlDataReader dr)
        {
            Terrain result = new();

            result.Id = dr.GetInt32("id_terrain");
            result.IdVille = dr.GetInt32("id_ville");
            result.IdCloture = dr.GetInt32("id_cloture");
            result.IdUtilisateur = dr.GetInt32("id_utilisateur");
            result.IdTypeTerrain = dr.GetInt32("id_type_terrain");
            result.Nom = dr.GetString("nom_terrain");
            result.Superficie = dr.GetFloat("superficie");
            result.Description = dr.GetString("description");
            result.DateAjout = dr.GetDateTime("date_ajout");
            result.AccesPublic = dr.GetBoolean("acces_public");
            result.AdresseVoie = dr.GetString("adresse_voie");
            result.Photo1 = dr.GetString("photo1");
            result.Photo2 = dr.GetString("photo2");
            result.Photo3 = dr.GetString("photo3");
            result.Photo4 = dr.GetString("photo4");
            result.Photo5 = dr.GetString("photo5");
            result.PresenceCamera = dr.GetBoolean("presence_camera");
            result.ServiceSecurite = dr.GetBoolean("presence_service_securite");

            if (!dr.IsDBNull(dr.GetOrdinal("adresse_lat")))
            {
                result.AdresseLong = dr.GetFloat("adresse_long");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("")))
            {
                result.AdresseLat = dr.GetFloat("adresse_lat");
            }
            return result;
        }

        public Terrain GetById(int id)
        {
            Terrain result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM terrain
                                WHERE id_terrain = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToTerrain(dr);
            }

            cmd.Connection.Close();

            return result;
        }

        public List<Terrain> GetAllByUtilisateurId(int id)
        {
            List<Terrain> result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM terrain
                                WHERE id_utilisateur = @id_utilisateur";

            cmd.Parameters.Add(new MySqlParameter("@id_utilisateur", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Terrain t = new();
                t = DataReaderToTerrain(dr);
                result.Add(t);
            }

            cmd.Connection.Close();

            return result;
        }
    }
}
