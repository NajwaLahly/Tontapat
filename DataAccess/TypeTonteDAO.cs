using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class TypeTonteDAO : DAO
    {
        private TypeTonte DataReaderToTypeTonte(MySqlDataReader dr)
        {
            TypeTonte result = new();
            result.Id = dr.GetInt32("id_type");
            result.Nom = dr.GetString("nom_type");
            result.CoefRapidite = dr.GetInt32("coef_rapidite");

            return result;
        }
        public List<TypeTonte> GetAll()
        {
            List<TypeTonte> result = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = "SELECT * FROM type_tonte";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TypeTonte t = DataReaderToTypeTonte(dr);

                result.Add(t);
            }

            cmd.Connection.Close();

            return result;
        }

        public TypeTonte GetById(int id)
        {
            TypeTonte result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM type_tonte
                                WHERE id_type = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToTypeTonte(dr);
            }

            cmd.Connection.Close();

            return result;
        }
    }
}
