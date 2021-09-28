using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DataAccessLibrary.Models;
using Dapper;


namespace DataAccessLibrary
{
    public class LocalizacaoData : ILocalizacaoData
    {
        public string conString =
            "Data Source=(local);Initial Catalog=LightsOut;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<LocalizacaoModel> GetLocalizacoes()
        {
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                return connection.Query<LocalizacaoModel>("select * from [LightsOut].[dbo].Localizacao").ToList();
            }
        }
    }
}