using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class TypeTerrainDAO : DAO
    {
        public List<TypeTerrain> GetAll()
        {
            List<TypeTerrain> terrains = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT * FROM type_terrain";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                TypeTerrain t = new();
                t.Id = dr.GetInt32("id_type_terrain");
                t.Nom = dr.GetString("nom_type_terrain");
                terrains.Add(t);
            }
            cmd.Connection.Close();
            return terrains;
        }
    }
}
