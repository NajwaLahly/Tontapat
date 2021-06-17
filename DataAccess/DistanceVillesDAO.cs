using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class DistanceVillesDAO : DAO
    {
        public double GetDistanceBetweenIds(int id1, int id2)
        {
            double distance = 0;
            MySqlCommand cmd = CreerCommande();
            cmd.CommandText = @"SELECT distance
                                FROM distance_villes d
                                WHERE (d.id_ville = @id1 AND d.vil_id_ville = @id2)
                                OR (d.id_ville = @id2 AND d.vil_id_ville = @id1)";

            cmd.Parameters.Add(new MySqlParameter("@id1", id1));
            cmd.Parameters.Add(new MySqlParameter("@id2", id2));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                distance = dr.GetDouble("distance");
            }

            cmd.Connection.Close();

            return distance;
        }
    }
}