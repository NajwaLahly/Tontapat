using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class EspeceDAO : DAO
    {
        private Espece DataReaderToEspece(MySqlDataReader dr)
        {
            Espece result = new();
            result.Id = dr.GetInt32("id_espece");
            result.Nom = dr.GetString("nom_espece");

            return result;
        }

        public List<Espece> GetAll()
        {
            List<Espece> result = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = "SELECT * FROM espece";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Espece e = DataReaderToEspece(dr);

                result.Add(e);
            }

            cmd.Connection.Close();

            return result;
        }

        public Espece GetById(int id)
        {
            Espece result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM espece
                                WHERE id_espece = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToEspece(dr);
            }

            cmd.Connection.Close();

            return result;
        }
    }
}
