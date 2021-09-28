using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DataAccessLibrary.Models;
using Dapper;

namespace DataAccessLibrary
{
    public class ProvaData : IProvaData
    {
        public string conString =
            "Data Source=(local);Initial Catalog=LightsOut;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<LocalizacaoModel> GetLocalizacoes()
        {
            /*Conecta á base de dados*/
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                /*Vê as epocas presentes na base de dados*/
                return connection.Query<LocalizacaoModel>("select * from [LightsOut].[dbo].Localizacao").ToList();
            }
        }

        public List<ProvaModel> ppppp(int ano, int ronda)
        {

            List<ProvaModel> result = new List<ProvaModel>();
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                string procuraProvas = String.Format("SELECT * from [LightsOut].[dbo].[Prova] where idEpoca = {0} and ronda < {1};", ano, ronda);
                var resultProvas = connection.Query(procuraProvas);

                foreach (var prova in resultProvas)
                {
                    string procuraLocalizacao =
                        String.Format(
                            "SELECT * from [LightsOut].[dbo].Localizacao where id = \'{0}\';", prova.idLocalizacao);

                    var resultLocalizacoes = connection.Query<LocalizacaoModel>(procuraLocalizacao).First();

                    DateTime d = prova.data + prova.horaProva;
                    //Console.WriteLine(d);
                    ProvaModel p = new ProvaModel(prova.id, prova.idEpoca, prova.ronda, prova.nomeProva, d, resultLocalizacoes);
                    result.Add(p);
                }

                return result;
            }
        }


        public List<ProvaModel> localizacaoProvasIntervalo(string dataInicial, string dataFinal)
        {

            List<ProvaModel> result = new List<ProvaModel>();
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                string procuraProvas = String.Format("SELECT * from [LightsOut].[dbo].[Prova] P where P.data >= '{0}' and P.data <= '{1}' order by P.data;", dataInicial, dataFinal);
                var resultProvas = connection.Query(procuraProvas);

                foreach (var prova in resultProvas)
                {
                    string procuraLocalizacao =
                        String.Format(
                            "SELECT * from [LightsOut].[dbo].Localizacao where id = \'{0}\';", prova.idLocalizacao);

                    var resultLocalizacoes = connection.Query<LocalizacaoModel>(procuraLocalizacao).First();

                    DateTime d = prova.data + prova.horaProva;
                    //Console.WriteLine(d);
                    ProvaModel p = new ProvaModel(prova.id, prova.idEpoca, prova.ronda, prova.nomeProva, d, resultLocalizacoes);
                    result.Add(p);
                }

                return result;
            }
        }



        public List<LocalizacaoModel> GetProvas()
        {

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                /*Vê as epocas presentes na base de dados*/
                return connection.Query<LocalizacaoModel>("SELECT L.* from [LightsOut].[dbo].[Prova] P JOIN Localizacao L on P.idLocalizacao = L.id where P.idEpoca = 2019;").ToList();
            }
        }


        public List<LocalizacaoModel> GetProvasIntervalo(int ano, int ronda)
        {

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                string procura = String.Format("SELECT L.* from [LightsOut].[dbo].[Prova] P JOIN Localizacao L on P.idLocalizacao = L.id where P.idEpoca = {0} and P.ronda < {1};", ano, ronda);

                /*Vê as epocas presentes na base de dados*/
                return connection.Query<LocalizacaoModel>(procura).ToList();
            }
        }
    }
}