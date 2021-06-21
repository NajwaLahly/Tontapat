using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class TypeVegeToxiqueDAO : DAO
    {
        public List<TypeVegeToxique> GetAll()
        {
            List<TypeVegeToxique> vegetations = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT * FROM type_vegetation_toxique";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TypeVegeToxique t = new();
                t.Id = dr.GetInt32("id_vegetation");
                t.Nom = dr.GetString("nom_vegetation");
                vegetations.Add(t);
            }
            cmd.Connection.Close();
            return vegetations;
        }
            

    }
}
