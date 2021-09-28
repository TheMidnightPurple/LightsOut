using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class ResultadoData : IResultadoData
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


        public Task<List<List<string>>> ResultadosProva(string nomeProva)
        {

            List<List<string>> listaResultados = new List<List<string>>();

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                string resultadosProva = String.Format(
                    "select top 20 R.posicaoFinal, P.nome, R.tempo, (case when Q.qualificacao2 = 'Eliminated in Q1' then Q.qualificacao1 when Q.qualificacao3 = 'Eliminated in Q2' then Q.qualificacao2 else Q.qualificacao3 end) as MelhorQualificacao, R.posicaoInicial, R.pontos from [LightsOut].[dbo].Qualificacao Q	join Resultado R on Q.idProva = R.idProva join Piloto P on R.idPiloto = P.id where Q.idProva = \'{0}\' and Q.idPiloto = R.idPiloto order by R.posicaoFinal;;", nomeProva);

                var results = connection.Query(resultadosProva);

                foreach (var result in results)
                {

                    List<string> rp = new List<string>();

                    rp.Add((result.posicaoFinal).ToString());
                    rp.Add(result.nome);
                    rp.Add(result.tempo);
                    rp.Add(result.MelhorQualificacao);
                    rp.Add((result.posicaoInicial).ToString());
                    rp.Add((result.pontos).ToString());

                    listaResultados.Add(rp);
                }
            }

            return Task.FromResult(listaResultados);
        }


        public Task<List<Tuple<string, int>>> ClassificacoesGeraisPiloto(int ano, int ronda)
        {

            Dictionary<string, List<int>> somatorio = new Dictionary<string, List<int>>();

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();


                string procuraResultados = String.Format(//lista com nome do piloto e pontos obtidos numa prova(várias provas)
                    "SELECT Piloto.nome, R.pontos from [LightsOut].[dbo].[Resultado] R JOIN Piloto Piloto On Piloto.id = R.idPiloto	JOIN Prova P On P.id = R.idProva where P.idEpoca = {0} and P.ronda <= {1} order by P.ronda;", ano, ronda);

                //Console.WriteLine(procuraResultados);
                var results = connection.Query(procuraResultados);


                foreach (var result in results)
                {

                    if (somatorio.ContainsKey(result.nome))
                    {//nome já existe

                        List<int> points = somatorio[result.nome];
                        points.Add(result.pontos);
                        somatorio[result.nome] = points;

                    }
                    else
                    {//nome ainda não existe
                        List<int> points = new List<int>();
                        points.Add(result.pontos);
                        somatorio[result.nome] = points;
                    }
                }

                Dictionary<string, int> resultados = new Dictionary<string, int>();

                foreach (KeyValuePair<string, List<int>> entry in somatorio)
                {
                    int totalPoints = entry.Value.Sum();
                    resultados[entry.Key] = totalPoints;
                }

                foreach (KeyValuePair<string, List<int>> entry in somatorio)
                {
                    int totalPoints = entry.Value.Sum();
                    resultados[entry.Key] = totalPoints;
                }

                List<Tuple<string, int>> sortedDict = new List<Tuple<string, int>>();

                foreach (var item in resultados.OrderByDescending(key => key.Value))
                {
                    Tuple<string, int> elem = new Tuple<string, int>(item.Key, item.Value);
                    sortedDict.Add(elem);
                }

                return Task.FromResult(sortedDict);
            }
        }

        public Task<List<Tuple<string, int>>> ClassificacoesGeraisEquipas(int ano, int ronda)
        {

            Dictionary<string, List<int>> somatorio = new Dictionary<string, List<int>>();

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();


                string procuraResultados = String.Format(//lista com nome do piloto e pontos obtidos numa prova(várias provas)
                    "SELECT Piloto.id, R.pontos from [LightsOut].[dbo].[Resultado] R JOIN Piloto Piloto On Piloto.id = R.idPiloto	JOIN Prova P On P.id = R.idProva where P.idEpoca = {0} and P.ronda <= {1} order by P.ronda;", ano, ronda);

                //Console.WriteLine(procuraResultados);
                var results = connection.Query(procuraResultados);

                foreach (var result in results)
                {

                    if (somatorio.ContainsKey(result.id))
                    {//nome já existe

                        List<int> points = somatorio[result.id];
                        points.Add(result.pontos);
                        somatorio[result.id] = points;

                    }
                    else
                    {//nome ainda não existe
                        List<int> points = new List<int>();
                        points.Add(result.pontos);
                        somatorio[result.id] = points;
                    }
                }

                Dictionary<string, int> resultados = new Dictionary<string, int>();

                foreach (KeyValuePair<string, List<int>> entry in somatorio)
                {
                    int totalPoints = entry.Value.Sum();
                    resultados[entry.Key] = totalPoints;
                }

                foreach (KeyValuePair<string, List<int>> entry in somatorio)
                {
                    int totalPoints = entry.Value.Sum();
                    resultados[entry.Key] = totalPoints;
                }//já temos piloto e total de pontos


                Dictionary<string, List<int>> somatorioEquipas = new Dictionary<string, List<int>>();

                foreach (KeyValuePair<string, int> pilotoPontos in resultados)
                {
                    string resultEquipa = String.Format(
                        "SELECT PE.idEquipa, E.nome from [LightsOut].[dbo].PilotoEquipa PE join Equipa E on PE.idEquipa = E.id where idPiloto = \'{0}\' and idEpoca = {1};", pilotoPontos.Key, ano);

                    var equipasPilotos = connection.Query(resultEquipa);

                    foreach (var equipaDoPiloto in equipasPilotos)
                    {
                        if (somatorioEquipas.ContainsKey(equipaDoPiloto.nome))
                        {//nome já existe

                            List<int> points = somatorioEquipas[equipaDoPiloto.nome];
                            points.Add(pilotoPontos.Value);
                            somatorioEquipas[equipaDoPiloto.nome] = points;

                        }
                        else
                        {//nome ainda não existe
                            List<int> points = new List<int>();
                            points.Add(pilotoPontos.Value);
                            somatorioEquipas[equipaDoPiloto.nome] = points;
                        }
                    }


                }//equipa e lista de pontos


                Dictionary<string, int> resultadosEquipas = new Dictionary<string, int>();

                foreach (KeyValuePair<string, List<int>> entry in somatorioEquipas)
                {
                    int totalPoints = entry.Value.Sum();
                    resultadosEquipas[entry.Key] = totalPoints;
                }

                foreach (KeyValuePair<string, List<int>> entry in somatorioEquipas)
                {
                    int totalPoints = entry.Value.Sum();
                    resultadosEquipas[entry.Key] = totalPoints;
                }//já temos equipa e total de pontos

                List<Tuple<string, int>> sortedDict = new List<Tuple<string, int>>();

                foreach (var item in resultadosEquipas.OrderByDescending(key => key.Value))
                {
                    Tuple<string, int> elem = new Tuple<string, int>(item.Key, item.Value);
                    sortedDict.Add(elem);
                }

                return Task.FromResult(sortedDict);
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