using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class TypeClotureDAO : DAO
    {
        public List<TypeCloture> GetAll()
        {
            List<TypeCloture> clotures = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT * FROM type_cloture";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TypeCloture t = new();
                t.Id = dr.GetInt32("id_cloture");
                t.Nom = dr.GetString("nom_cloture");
                clotures.Add(t);
            }
            cmd.Connection.Close();
            return clotures;
        }
    }
}
