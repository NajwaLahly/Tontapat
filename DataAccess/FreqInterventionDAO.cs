using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class FreqInterventionDAO : DAO
    {
        private FreqIntervention DataReaderToFreqIntervention(MySqlDataReader dr)
        {
            FreqIntervention result = new();
            result.Id = dr.GetInt32("id_frequence");
            result.Valeur = dr.GetInt32("valeur_frequence");

            return result;
        }

        public List<FreqIntervention> GetAll()
        {
            List<FreqIntervention> result = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = "SELECT * FROM frequence_intervention";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FreqIntervention t = DataReaderToFreqIntervention(dr);

                result.Add(t);
            }

            cmd.Connection.Close();

            return result;
        }

        public FreqIntervention GetById(int id)
        {
            FreqIntervention result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM frequence_intervention
                                WHERE id_frequence = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToFreqIntervention(dr);
            }

            cmd.Connection.Close();

            return result;
        }
    }
}
