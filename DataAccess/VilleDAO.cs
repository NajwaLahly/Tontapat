using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class VilleDAO : DAO
    {
        public List<Ville> GetAll()
        {
            List<Ville> result = new List<Ville>();
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"Select * FROM ville";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ville v = new Ville();
                v.Id = dr.GetInt32("id_ville");
                v.NomVille = dr.GetString("nom_ville");
                v.CodePostal = dr.GetInt32("code_postal");
                result.Add(v);
            }

            cmd.Connection.Close();
            return result;
        }

    }
}
