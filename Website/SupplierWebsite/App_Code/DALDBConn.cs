﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Supplier.DataAccessLayer
{
    public class DALDBConn
    {
        public SqlConnection GetConnection()
        {
            SqlConnection dbConn;
            String connString = ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;

            dbConn = new SqlConnection(connString);

            return dbConn;
        }
            

    }
}