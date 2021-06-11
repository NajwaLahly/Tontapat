﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.DataAccess
{
    public class DAO
    {
        private const string CONNECTION_STRING = "Server=localhost;Database=tontapat;Uid=root;Pwd=root;";

        protected MySqlCommand CreerCommande()
        {
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = CONNECTION_STRING;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            return cmd;
        }
    }
}
