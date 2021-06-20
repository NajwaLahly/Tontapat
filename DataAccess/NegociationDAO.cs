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
        public void create(Negociation n) { 
        MySqlCommand cmd = CreerCommande();
        #region config command
        cmd.CommandText = @"INSERT INTO negociation 
                                (id_negociation, id_prestation, id_offre, date_ouverture, date_fermeture, id_nouvelle_prestation) 
                                VALUES (@id_negociation, @id_prestation, @id_offre, @date_ouverture, @date_fermeture, @id_nouvelle_prestation) ";

            cmd.Parameters.Add(new MySqlParameter("@id_negociation", n.Id));
            cmd.Parameters.Add(new MySqlParameter("@id_prestation", n.IdPrestation));
            cmd.Parameters.Add(new MySqlParameter("@id_offre", n.IdOffre));
            cmd.Parameters.Add(new MySqlParameter("@date_ouverture", n.DateOuverture));
            cmd.Parameters.Add(new MySqlParameter("@date_fermeture", n.DateFermeture));
            cmd.Parameters.Add(new MySqlParameter("@id_nouvelle_prestation", n.IdNouvellePrestation));
            #endregion
            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }
    }
}
