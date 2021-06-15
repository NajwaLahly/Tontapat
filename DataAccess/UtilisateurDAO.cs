using Fr.EQL.AI109.Tontapat.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class UtilisateurDAO : DAO
    {
        public void Create(Utilisateur u)
        {
            MySqlCommand cmd = CreerCommande();
            #region command
            cmd.CommandText = @"INSERT INTO utilisateur (id_ville, id_type_client, email, mot_de_passe, date_naissance, date_inscription, 
                                photo_profil, nom, prenom, raison_sociale, adresse_voie, adresse_long, adresse_lat, carte_numero, carte_expiration, 
                                carte_cvc, virement_iban, virement_bic, paypal_email) VALUES (@id_ville, @id_type_client, @email, @mot_de_passe, 
                                @date_naissance, @date_inscription, @photo_profil, @nom, @prenom, @raison_sociale, @adresse_voie, @adresse_long,
                                @adresse_lat, @carte_numero, @carte_expiration, @carte_cvc, @virement_iban, @virement_bic, @paypal_email)";

            cmd.Parameters.Add(new MySqlParameter("@id_ville", u.IdVille));
            cmd.Parameters.Add(new MySqlParameter("@id_type_client", u.IdTypeClient));
            cmd.Parameters.Add(new MySqlParameter("@email", u.Email));
            cmd.Parameters.Add(new MySqlParameter("@mot_de_passe", u.MotDePasse));
            cmd.Parameters.Add(new MySqlParameter("@date_naissance", u.DateNaissance));
            cmd.Parameters.Add(new MySqlParameter("@date_inscription", u.DateInscription));
            cmd.Parameters.Add(new MySqlParameter("@photo_profil", u.PhotoProfil));
            cmd.Parameters.Add(new MySqlParameter("@nom", u.Nom));
            cmd.Parameters.Add(new MySqlParameter("@prenom", u.Prenom));
            cmd.Parameters.Add(new MySqlParameter("@raison_sociale", u.RaisonSociale));
            cmd.Parameters.Add(new MySqlParameter("@adresse_voie", u.AdresseVoie));
            cmd.Parameters.Add(new MySqlParameter("@adresse_long", u.AdresseLong));
            cmd.Parameters.Add(new MySqlParameter("@adresse_lat", u.AdresseLat));
            cmd.Parameters.Add(new MySqlParameter("@carte_numero", u.CarteNumero));
            cmd.Parameters.Add(new MySqlParameter("@carte_expiration", u.CarteExpiration));
            cmd.Parameters.Add(new MySqlParameter("@carte_cvc", u.CarteCVC));
            cmd.Parameters.Add(new MySqlParameter("@virement_iban", u.VirementIBAN));
            cmd.Parameters.Add(new MySqlParameter("@virement_bic", u.BIC));
            cmd.Parameters.Add(new MySqlParameter("@paypal_email", u.PayPalEmail));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            #endregion

        }

        public Utilisateur GetById(int id)
        {
            Utilisateur result = null;
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT *
                                FROM utilisateur
                                WHERE id_utilisateur = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToUtilisateur(dr);
            }

            cmd.Connection.Close();

            return result;
        }

        public UtilisateurDetail GetAllWithDetailsById(int id)
        {
            UtilisateurDetail result = new();
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT u.*, e.note_evaluation, v.nom_ville
                                FROM utilisateur u 
                                LEFT JOIN evaluation e ON e.id_utilisateur = u.id_utilisateur
                                LEFT JOIN ville v ON v.id_ville = u.id_ville
                                WHERE u.id_utilisateur= @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Utilisateur u = DataReaderToUtilisateur(dr);

                result.Id = u.Id;
                result.IdVille = u.IdVille;
                result.IdTypeClient = u.IdTypeClient;
                result.Email = u.Email;
                result.MotDePasse = u.MotDePasse;
                result.DateNaissance = u.DateNaissance;
                result.DateInscription = u.DateInscription;
                result.PhotoProfil = u.PhotoProfil;
                result.Nom = u.Nom;
                result.Prenom = u.Prenom;
                result.RaisonSociale = u.RaisonSociale;
                result.AdresseVoie = u.AdresseVoie;
                result.AdresseLong = u.AdresseLong;
                result.AdresseLat = u.AdresseLat;
                result.CarteNumero = u.CarteNumero;
                result.CarteExpiration = u.CarteExpiration;
                result.CarteCVC = u.CarteCVC;
                result.VirementIBAN = u.VirementIBAN;
                result.BIC = u.BIC;
                result.PayPalEmail = u.PayPalEmail;
                result.Presentation = u.Presentation;
                result.NomVille = dr.GetString("nom_ville");
                result.Moyenne = GetAverageByUtilisateurId(id);
            }

            cmd.Connection.Close();

            return result;
        }
        public List<Utilisateur> GetAll()
        {
            List<Utilisateur> result = new List<Utilisateur>();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = "SELECT * FROM utilisateur";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Utilisateur u = DataReaderToUtilisateur(dr);

                result.Add(u);
            }

            cmd.Connection.Close();

            return result;
        }

        public double GetAverageByUtilisateurId(int id)
        {
            double result = new();
            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT AVG(note_evaluation) 'average' FROM evaluation e
	                            WHERE id_utilisateur = @id;";

            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (!dr.IsDBNull(dr.GetOrdinal("average")))
                {
                    result = dr.GetDouble("average");
                }
                    
            }
            else
            {
                result = -1;
            }

            cmd.Connection.Close();
            return result;
        }

        public Utilisateur DataReaderToUtilisateur(MySqlDataReader dr)
        {
            Utilisateur result = new Utilisateur();

            result.Id = dr.GetInt32("id_utilisateur");
            result.IdVille = dr.GetInt32("id_ville");

            if(!dr.IsDBNull(dr.GetOrdinal("id_type_client")))
            {
                result.IdTypeClient = dr.GetInt32("id_type_client");
            }
            result.Email = dr.GetString("email");
            result.MotDePasse = dr.GetString("mot_de_passe");
            result.DateNaissance = dr.GetDateTime("date_naissance");
            result.DateInscription = dr.GetDateTime("date_inscription");
            if (!dr.IsDBNull(dr.GetOrdinal("photo_profil")))
            { 
                result.PhotoProfil = dr.GetString("photo_profil");
            }
            result.Nom = dr.GetString("nom");
            result.Prenom = dr.GetString("prenom");
            if(!dr.IsDBNull(dr.GetOrdinal("raison_sociale")))
            {
                result.RaisonSociale = dr.GetString("raison_sociale");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("adresse_voie")))
            {
                result.AdresseVoie = dr.GetString("adresse_voie");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("adresse_long")))
            {
                result.AdresseLong = dr.GetFloat("adresse_long");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("adresse_lat")))
            {
                result.AdresseLat = dr.GetFloat("adresse_lat");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("carte_numero")))
            {
                result.CarteNumero = dr.GetInt64("carte_numero");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("carte_expiration")))
            {
                result.CarteExpiration = dr.GetDateTime("carte_expiration");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("carte_cvc")))
            {
                result.CarteCVC = dr.GetInt32("carte_cvc");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("virement_iban")))
            {
                result.VirementIBAN = dr.GetString("virement_iban");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("virement_bic")))
            {
                result.BIC = dr.GetString("virement_bic");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("paypal_email")))
            {
                result.PayPalEmail = dr.GetString("paypal_email");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("presentation")))
            {
                result.Presentation = dr.GetString("presentation");
            }

            return result;


        }
    }
}
