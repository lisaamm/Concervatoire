﻿using CliLourdConservatoire.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CliLourdConservatoire.DAL
{
    /// <summary>
    /// Couche contenant les méthodes d'accès aux données des trimestres
    /// </summary>
    public class TrimestreDAO
    {
        private static ConnexionSql connect = ConnexionSql.getInstance("localhost", "conservatoire", "root", "");

        /// <summary>
        /// récupérer les données d'un trimestre selon son libelle
        /// </summary>
        /// <param name="trim"></param>
        /// <returns type="Trimestre"></returns>
        public static Trimestre getByTrimestre(string trim)
        {
            connect.openConnection();

            MySqlCommand request = connect.reqExec("select * from trim where libelle = '" + trim + "';");

            MySqlDataReader reader = connect.queryExec(request);

            Trimestre trimestre = null;

            while (reader.Read())
            {
                string libelle = (string)reader[0];
                DateTime dateFin = (DateTime)reader[1];
                
                trimestre = new Trimestre(libelle, dateFin);

            }

            reader.Close();
            connect.closeConnection();

            return trimestre;
        }
    }
}
