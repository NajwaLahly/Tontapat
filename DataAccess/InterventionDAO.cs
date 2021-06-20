using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class InterventionDAO : DAO
    {

        private Intervention DataReaderToIntervention(MySqlDataReader dr)
        {
            Intervention result = new();
            result.Id = dr.GetInt32("id_intervention");
            result.IdPrestation = dr.GetInt32("id_prestation");
            result.DateIntervention = dr.GetDateTime("date_intervention");

            if (!dr.IsDBNull(dr.GetOrdinal("id_motif")))
            {
                result.IdMotif = dr.GetInt32("id_motif");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_demande")))
            {
                result.DateDemande = dr.GetDateTime("date_demande");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("description_demande")))
            {
                result.DescriptionDemande = dr.GetString("description_demande");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_validation_demande")))
            {
                result.DateValidationDemande = dr.GetDateTime("date_validation_demande");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_refus_demande")))
            {
                result.DateRefusDemande = dr.GetDateTime("date_refus_demande");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_validation_intervention")))
            {
                result.DateValidationIntervention = dr.GetDateTime("date_validation_intervention");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("description_validation")))
            {
                result.DescriptionValidation = dr.GetString("description_validation");
            }

            return result;
        }

        public void Create(Intervention p)
        {

        }
    }
}
