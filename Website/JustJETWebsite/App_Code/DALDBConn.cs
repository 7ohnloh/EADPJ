﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DALDBConn
/// </summary>
public class DALDBConn
{
   
       public SqlConnection GetConnection()
    {
        SqlConnection dbConn;
        String connString = ConfigurationManager.ConnectionStrings["JustJETConnectionString"].ConnectionString;

        dbConn = new SqlConnection(connString);

        return dbConn;
    }
}