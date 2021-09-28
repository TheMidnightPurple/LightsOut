using System;
using System.Data.SqlClient;
using System.Linq;
using DataAccessLibrary.Models;
using Dapper;

namespace DataAccessLibrary
{
    public class UtilizadorData : IUtilizadorData
    {
        public string conString =
            "Data Source=(local);Initial Catalog=LightsOut;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool addUserBaseDados(string utilizador, string password)
        {
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                /*Vê as epocas presentes na base de dados*/
                if (connection.Query<UtilizadorModel>(String.Format("select * from [LightsOut].[dbo].Utilizador where nome = '{0}'", utilizador)).ToList().Count == 1) return false;
                else
                {
                    UtilizadorModel u = new UtilizadorModel(utilizador, password);
                    connection.Query(String.Format("insert into [LightsOut].[dbo].Utilizador values ('{0}', '{1}')",
                        utilizador, password));
                }
            }

            return true;
        }
    }
}