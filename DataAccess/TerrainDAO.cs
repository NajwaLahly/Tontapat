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

        public void Update(Terrain t)
        {
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"UPDATE terrain SET id_ville = @id_ville, id_cloture = @id_cloture, id_utilisateur = @id_utilisateur,
                                id_type_terrain = @id_type_terrain, nom_terrain = @nom_terrain, superficie_terrain = @superficie_terrain,
                                description = @description, date_ajout = @date_ajout, acces_public = @acces_public, adresse_lat = @adresse_lat,
                                adresse_long = @adresse_long, adresse_voie = @adresse_voie, photo1 = @photo1, photo2 = @photo2, photo3 = @photo3,
                                photo4 = @photo4, photo5 = @photo5, date_retrait_terrain = @date_retrait_terrain, presence_camera = @presence_camera,
                                presence_service_securite = @presence_service_securite
                                WHERE id_terrain = @id_terrain;";

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
            cmd.Parameters.Add(new MySqlParameter("@date_retrait_terrain", t.DateRetrait));
            cmd.Parameters.Add(new MySqlParameter("@photo1", t.Photo1));
            cmd.Parameters.Add(new MySqlParameter("@photo2", t.Photo2));
            cmd.Parameters.Add(new MySqlParameter("@photo3", t.Photo3));
            cmd.Parameters.Add(new MySqlParameter("@photo4", t.Photo4));
            cmd.Parameters.Add(new MySqlParameter("@photo5", t.Photo5));
            cmd.Parameters.Add(new MySqlParameter("@presence_camera", t.PresenceCamera));
            cmd.Parameters.Add(new MySqlParameter("@presence_service_securite", t.ServiceSecurite));
            cmd.Parameters.Add(new MySqlParameter("id_terrain", t.Id));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }
        public void RetraitTerrain(int id)
        {
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"UPDATE terrain SET date_retrait_terrain = SYSDATE()
                            where id_terrain = @id";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
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
            List<Terrain> result = new();
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM terrain
                                WHERE id_utilisateur = @id_utilisateur";

            cmd.Parameters.Add(new MySqlParameter("@id_utilisateur", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Terrain t = DataReaderToTerrain(dr);
                result.Add(t);
            }

            cmd.Connection.Close();

            return result;
        }

        public List<TerrainDetail> GetAllWithDetailByUtilisateurId(int id)
        {
            List<TerrainDetail> terrains = new();

            MySqlCommand cmd = CreerCommande();
            cmd.CommandText = @"SELECT tr.*, tc.nom_cloture, v.nom_ville, v.code_postal, tt.nom_type_terrain
                                FROM terrain tr
                                LEFT JOIN type_cloture tc ON tc.id_cloture = tr.id_cloture
                                LEFT JOIN type_terrain tt ON tt.id_type_terrain = tr.id_type_terrain
                                LEFT JOIN ville v ON v.id_ville = tr.id_ville 
                                WHERE id_utilisateur = @id_utilisateur;";

            cmd.Parameters.Add(new MySqlParameter("@id_utilisateur", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TerrainDetail td = DataReaderToTerrainDetail(dr);
                terrains.Add(td);
            }

            cmd.Connection.Close();
            return terrains;
        }

        public TerrainDetail GetWithDetailById(int id)
        {
            TerrainDetail terrain = new();

            MySqlCommand cmd = CreerCommande();
            cmd.CommandText = @"SELECT tr.*, tc.nom_cloture, v.nom_ville, v.code_postal, tt.nom_type_terrain
                                FROM terrain tr
                                LEFT JOIN type_cloture tc ON tc.id_cloture = tr.id_cloture
                                LEFT JOIN type_terrain tt ON tt.id_type_terrain = tr.id_type_terrain
                                LEFT JOIN ville v ON v.id_ville = tr.id_ville 
                                WHERE tr.id_terrain = @id_terrain;";

            cmd.Parameters.Add(new MySqlParameter("@id_terrain", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                terrain = DataReaderToTerrainDetail(dr);
      
            }

            cmd.Connection.Close();
            return terrain;
        }
        private TerrainDetail DataReaderToTerrainDetail(MySqlDataReader dr)
        {
            Terrain tr = DataReaderToTerrain(dr);
            TerrainDetail td = new();

            td.Id = tr.Id;
            td.IdVille = tr.IdVille;
            td.IdCloture = tr.IdCloture;
            td.IdUtilisateur = tr.IdUtilisateur;
            td.IdTypeTerrain = tr.IdTypeTerrain;
            td.Nom = tr.Nom;
            td.Description = tr.Description;
            td.Superficie = tr.Superficie;
            td.DateAjout = tr.DateAjout;
            td.AccesPublic = tr.AccesPublic;
            td.AdresseLat = tr.AdresseLat;
            td.AdresseLong = tr.AdresseLong;
            td.AdresseVoie = tr.AdresseVoie;
            td.PresenceCamera = tr.PresenceCamera;
            td.ServiceSecurite = tr.ServiceSecurite;
            td.DateRetrait = tr.DateRetrait;
            td.CodePostal = dr.GetInt32("code_postal");
            td.Ville = dr.GetString("nom_ville");
            td.Cloture = dr.GetString("nom_cloture");
            td.Type = dr.GetString("nom_type_terrain");

            return td;
            
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
            result.Superficie = dr.GetFloat("superficie_terrain");
            result.Description = dr.GetString("description");
            result.DateAjout = dr.GetDateTime("date_ajout");
            result.AccesPublic = dr.GetBoolean("acces_public");
            result.AdresseVoie = dr.GetString("adresse_voie");
            if(!dr.IsDBNull(dr.GetOrdinal("photo1")))
            {
                result.Photo1 = dr.GetString("photo1");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("photo2")))
            {
                result.Photo1 = dr.GetString("photo2");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("photo3")))
            {
                result.Photo1 = dr.GetString("photo3");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("photo4")))
            {
                result.Photo1 = dr.GetString("photo4");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("photo5")))
            {
                result.Photo1 = dr.GetString("photo5");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_retrait_terrain")))
            {
                result.DateRetrait = dr.GetDateTime("date_retrait_terrain");
            }

            result.PresenceCamera = dr.GetBoolean("presence_camera");
            result.ServiceSecurite = dr.GetBoolean("presence_service_securite");

            if (!dr.IsDBNull(dr.GetOrdinal("adresse_long")))
            {
                result.AdresseLong = dr.GetFloat("adresse_long");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("adresse_lat")))
            {
                result.AdresseLat = dr.GetFloat("adresse_lat");
            }
            return result;
        }

        public List<Terrain> GetLatest(int id, int nbre)
        {
            List<Terrain> allTerrain = GetAllByUtilisateurId(id);
            List<Terrain> result = new List<Terrain>(); 
            for (int i = 0; i < nbre; i++)
                {
                    result.Add(allTerrain.ElementAt(i));
                }
            return result;
        }
    }
}
