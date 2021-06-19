using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class NegociationDAO : DAO
    {
        public void Create(Negociation n)
        {
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"INSERT INTO negociation
                                (id_prestation, id_offre, date_ouverture)
                                VALUES
                                (@id_prestation, @id_offre, @date_ouverture)";

            cmd.Parameters.Add(new MySqlParameter("@id_prestation", n.IdPrestation));
            cmd.Parameters.Add(new MySqlParameter("@id_offre", n.IdOffre));
            cmd.Parameters.Add(new MySqlParameter("@date_ouverture", n.DateOuverture));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }
        private Negociation DataReaderToNegociation(MySqlDataReader dr)
        {
            Negociation result = new Negociation();
            result.Id = dr.GetInt32("id_negociation");
            result.IdPrestation = dr.GetInt32("id_prestation");
            result.DateOuverture = dr.GetDateTime("date_ouverture");
            if (!dr.IsDBNull(dr.GetOrdinal("id_nouvelle_prestation")))
            {
                result.IdNouvellePrestation = dr.GetInt32("id_nouvelle_prestation");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_offre")))
            {
                result.IdOffre = dr.GetInt32("id_offre");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_fermeture")))
            {
                result.DateFermeture = dr.GetDateTime("date_fermeture");
            }
            return result;
        }

        private NegociationDetail DataReaderToNegociationDetail(MySqlDataReader dr)
        {
            Negociation n = DataReaderToNegociation(dr);
            NegociationDetail result = new();
            result.Id = n.Id;
            result.IdPrestation = n.IdPrestation;
            result.DateOuverture = n.DateOuverture;
            result.IdNouvellePrestation = n.IdNouvellePrestation;
            result.IdOffre = n.IdOffre;
            result.DateFermeture = n.DateFermeture;

            return result;
        }

        public List<NegociationDetail> GetAllWithDetailsByPrestationId(int id)
        {
            List<NegociationDetail> result = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT n.* from negociation n
                                WHERE id_prestation = @id_prestation";
            cmd.Parameters.Add(new MySqlParameter("@id_prestation", id));

            cmd.Connection.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result.Add(DataReaderToNegociationDetail(dr));
            }
            cmd.Connection.Close();

            return result;
        }

        public NegociationDetail GetWithDetailsById(int id)
        {
            NegociationDetail result = new();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT n.* from negociation n
                                WHERE id_prestation = @id";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToNegociationDetail(dr);
            }
            cmd.Connection.Close();

            return result;
        }

        public void Update(Negociation n)
        {
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"UPDATE negociation
                                SET date_fermeture = @date_fermeture,
                                id_nouvelle_prestation = @id_nouvelle_prestation
                                WHERE id_negociation = @id_negociation";

            cmd.Parameters.Add(new MySqlParameter("@date_fermeture", n.DateFermeture));
            cmd.Parameters.Add(new MySqlParameter("@id_nouvelle_prestation", n.IdNouvellePrestation));
            cmd.Parameters.Add(new MySqlParameter("@id_negociation", n.Id));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }

    }
}
