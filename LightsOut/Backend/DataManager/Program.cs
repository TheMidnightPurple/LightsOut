using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Dapper;
using Newtonsoft.Json.Linq;

namespace LightsOut
{
    public class DataManager
    {
        
        public string conString =
            "Data Source=(local);Initial Catalog=LightsOut;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        void loadEpocas(int from, int to) {
            
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                var existeEpocas = "select * from [LightsOut].[dbo].Epoca;";
                var existeEpocasBD = connection.Query(existeEpocas);

                if (existeEpocasBD.Count() == 0)//ainda não existem épocas na BD
                {
                    for (int epoca = from; epoca <= to; epoca++)
                    {
                        var sql = String.Format("If Not Exists(select * from [LightsOut].[dbo].Epoca where ano=\'{0}\') begin insert into [LightsOut].[dbo].Epoca values ({0}) end", epoca);
                        connection.Query(sql);
                    }
                    
                    Console.WriteLine("Epocas Adicionadas!");
                }
                else//já existem épocas na base de dados
                {
                    Console.WriteLine("Não foi adicionada nenhuma Época");
                }
            }
        }
        
        void loadCircuitos() {
            
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existeCircuitos = "select * from [LightsOut].[dbo].Localizacao;";
                var existeCircuitosBD = connection.Query(existeCircuitos);

                if (existeCircuitosBD.Count() == 0)//não há circuitos na BD
                {
                    var result = connection.Query<int>("select ano from [LightsOut].[dbo].Epoca").ToList();

                    foreach (var epoca in result)
                    {
                        JObject info = getJsonFromURL(String.Format("http://ergast.com/api/f1/{0}/circuits.json",epoca));
                        foreach (var circuito in info["MRData"]["CircuitTable"]["Circuits"].ToList())
                        {
                            var sql = String.Format(
                                "If Not Exists(select * from [LightsOut].[dbo].Localizacao where id=\'{0}\') Begin insert into [LightsOut].[dbo].Localizacao values (\'{0}\',\'{1}\',\'{2}\',{3},{4}) End",
                                circuito["circuitId"],circuito["circuitName"],circuito["Location"]["country"] ,circuito["Location"]["lat"],circuito["Location"]["long"]);
                            
                            connection.Query(sql);
                        
                        }
                    }
                }
                else//já existem Circuitos na base de dados, logo metemos apenas os de 20201
                {
                    JObject info = getJsonFromURL("http://ergast.com/api/f1/2021/circuits.json");
                    foreach (var circuito in info["MRData"]["CircuitTable"]["Circuits"].ToList())
                    {
                        var sql = String.Format(
                            "If Not Exists(select * from [LightsOut].[dbo].Localizacao where id=\'{0}\') Begin insert into [LightsOut].[dbo].Localizacao values (\'{0}\',\'{1}\',\'{2}\',{3},{4}) End",
                            circuito["circuitId"],circuito["circuitName"],circuito["Location"]["country"] ,circuito["Location"]["lat"],circuito["Location"]["long"]);
                        
                        connection.Query(sql);
                        
                    }
                    Console.WriteLine("Foram adicionados circuitos mais recentes");
                }
            }
        }
        
        
        void loadEquipas() {
            
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existeEquipas = "select * from [LightsOut].[dbo].Equipa;";
                var existeEquipasBD = connection.Query(existeEquipas);

                if (existeEquipasBD.Count() == 0)//ainda não existem equipas na BD
                {
                    var result = connection.Query<int>("select ano from [LightsOut].[dbo].Epoca").ToList();

                    foreach (var epoca in result)
                    {
                        JObject info = getJsonFromURL(String.Format("http://ergast.com/api/f1/{0}/constructors.json",epoca));
                        foreach (var equipa in info["MRData"]["ConstructorTable"]["Constructors"].ToList())
                        {
                            var sql = String.Format(
                                "If Not Exists(select * from [LightsOut].[dbo].Equipa where id=\'{0}\') Begin insert into [LightsOut].[dbo].Equipa values (\'{0}\',\'{1}\', \'{2}\') End",
                                equipa["constructorId"], equipa["name"], equipa["nationality"]);
                            
                            connection.Query(sql);
                        
                        }
                    }
                }
                else//já existem Equipas na base de dados
                {
                    JObject info = getJsonFromURL("http://ergast.com/api/f1/2021/constructors.json");
                    foreach (var equipa in info["MRData"]["ConstructorTable"]["Constructors"].ToList())
                    {
                        var sql = String.Format(
                            "If Not Exists(select * from [LightsOut].[dbo].Equipa where id=\'{0}\') Begin insert into [LightsOut].[dbo].Equipa values (\'{0}\',\'{1}\', \'{2}\') End",
                            equipa["constructorId"], equipa["name"], equipa["nationality"]);
                        
                        connection.Query(sql);
                        
                    }
                    
                    Console.WriteLine("Foram adicionadas Equipas mais recentes");   
                }
            }
        }
        
        void loadPilotos() {
           
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existePilotos = "select * from [LightsOut].[dbo].Piloto;";
                var existePilotosBD = connection.Query(existePilotos);

                if (existePilotosBD.Count() == 0)
                {
                    var result = connection.Query<int>("select ano from [LightsOut].[dbo].Epoca").ToList();

                    foreach (var epoca in result)
                    {
                        JObject info = getJsonFromURL(String.Format("http://ergast.com/api/f1/{0}/drivers.json",epoca));
                        foreach (var piloto in info["MRData"]["DriverTable"]["Drivers"].ToList())
                        {
                            var sql = String.Format(
                                "If Not Exists(select * from [LightsOut].[dbo].Piloto where id=\'{0}\') Begin insert into [LightsOut].[dbo].Piloto values (\'{0}\',\'{1}\') End",
                                piloto["driverId"], piloto["givenName"].ToString().Replace("'", "`") + " " + piloto["familyName"].ToString().Replace("'", "`"));
                        
                            //Console.WriteLine(sql);
                            connection.Query(sql);
                        }
                    }
                }
                else//já existem pilotos na BD
                {
                    JObject info = getJsonFromURL("http://ergast.com/api/f1/2021/drivers.json");
                    foreach (var piloto in info["MRData"]["DriverTable"]["Drivers"].ToList())
                    {
                        var sql = String.Format(
                            "If Not Exists(select * from [LightsOut].[dbo].Piloto where id=\'{0}\') Begin insert into [LightsOut].[dbo].Piloto values (\'{0}\',\'{1}\') End",
                            piloto["driverId"], piloto["givenName"].ToString().Replace("'", "`") + " " + piloto["familyName"].ToString().Replace("'", "`"));
                        
                        //Console.WriteLine(sql);
                        connection.Query(sql);
                    }
                    
                    Console.WriteLine("Foram adicionados pilotos mais recentes");
                }
            }
        }       

        void loadProvas() {
            
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existeProvas = "select * from [LightsOut].[dbo].Prova;";
                var existeProvasBD = connection.Query(existeProvas);

                if (existeProvasBD.Count() == 0)
                {
                    var result = connection.Query<int>("select ano from [LightsOut].[dbo].Epoca").ToList();

                    foreach (var epoca in result)
                    {
                        JObject info = getJsonFromURL(String.Format("http://ergast.com/api/f1/{0}.json",epoca));
                    
                        foreach (var prova in info["MRData"]["RaceTable"]["Races"].ToList())
                        {
                            string id = prova["raceName"].ToString().Replace(" ", "") + prova["season"].ToString();
                        
                            var sql = String.Format(
                                "If Not Exists(select * from [LightsOut].[dbo].Prova where id=\'{0}\') Begin insert into [LightsOut].[dbo].Prova values (\'{0}\',{1},{2},\'{3}\',\'{4}\', \'{5}\', \'{6}\') End",
                                id, prova["season"], prova["round"] ,prova["raceName"],prova["date"], prova["time"], prova["Circuit"]["circuitId"]);
                            
                            connection.Query(sql);
                        }
                    }
                }
                else
                {
                    JObject info = getJsonFromURL("http://ergast.com/api/f1/2021.json");
                    
                    foreach (var prova in info["MRData"]["RaceTable"]["Races"].ToList())
                    {
                        string id = prova["raceName"].ToString().Replace(" ", "") + prova["season"].ToString();
                        
                        var sql = String.Format(
                            "If Not Exists(select * from [LightsOut].[dbo].Prova where id=\'{0}\') Begin insert into [LightsOut].[dbo].Prova values (\'{0}\',{1},{2},\'{3}\',\'{4}\', \'{5}\', \'{6}\') End",
                            id, prova["season"], prova["round"] ,prova["raceName"],prova["date"], prova["time"], prova["Circuit"]["circuitId"]);
                        
                        connection.Query(sql);
                    }
                    Console.WriteLine("Foram adicionadas provas mais recentes");
                }
            }
        }


        void loadPilotosEquipas(){

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existePilotosEquipa = "select * from [LightsOut].[dbo].PilotoEquipa;";
                var existePilotosEquipaBD = connection.Query(existePilotosEquipa);

                if (existePilotosEquipaBD.Count() == 0)
                {
                    var result = connection.Query<int>("select ano from [LightsOut].[dbo].Epoca").ToList();

                    foreach (var epoca in result)
                    {
                        JObject info = getJsonFromURL(String.Format("http://ergast.com/api/f1/{0}/1/results.json",epoca));
                        foreach (var resultado in info["MRData"]["RaceTable"]["Races"][0]["Results"].ToList())
                        {
                            var sql = String.Format(
                                "If Not Exists(select * from [LightsOut].[dbo].PilotoEquipa where idPiloto=\'{0}\' and idEquipa=\'{1}\' and idEpoca = {2}) Begin insert into [LightsOut].[dbo].PilotoEquipa values (\'{0}\',\'{1}\',{2}) End",
                                resultado["Driver"]["driverId"], 
                                resultado["Constructor"]["constructorId"],
                                epoca);
                        
                            //Console.WriteLine(sql);
                            connection.Query(sql);
                        }
                    }
                }
                else
                {
                    JObject info = getJsonFromURL("http://ergast.com/api/f1/2021/1/results.json");
                    foreach (var resultado in info["MRData"]["RaceTable"]["Races"][0]["Results"].ToList())
                    {
                        var sql = String.Format(
                            "If Not Exists(select * from [LightsOut].[dbo].PilotoEquipa where idPiloto=\'{0}\' and idEquipa=\'{1}\' and idEpoca = 2021) Begin insert into [LightsOut].[dbo].PilotoEquipa values (\'{0}\',\'{1}\',2021) End",
                            resultado["Driver"]["driverId"],
                            resultado["Constructor"]["constructorId"]);
                        
                        //Console.WriteLine(sql);
                        connection.Query(sql);
                    }
                    Console.WriteLine("Foram adicionados PilotoEquipa mais recentes");
                }
            }
        }
        
        
        void loadResults() {
            
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existeResultados = "select * from [LightsOut].[dbo].Resultado;";
                var existeResultadosBD = connection.Query(existeResultados);

                if (existeResultadosBD.Count() == 0)
                {
                    var provas = connection.Query("select * from [LightsOut].[dbo].Prova").ToList();

                    foreach (var prova in provas)
                    {
                        JObject results = getJsonFromURL(String.Format("http://ergast.com/api/f1/{0}/{1}/results.json",prova.idEpoca, prova.ronda));
                        var corridas = results["MRData"]["RaceTable"]["Races"] as JArray;
                    
                        if (corridas.Count() != 0)
                        {
                            foreach (var result in results["MRData"]["RaceTable"]["Races"][0]["Results"].ToList())
                            {
                                var sql = String.Format(
                                    "If Not Exists(select * from [LightsOut].[dbo].Resultado where idPiloto = \'{0}\' and idProva = \'{1}\') begin insert into [LightsOut].[dbo].Resultado values (\'{1}\',\'{0}\',{2}, {3}, \'{4}\',{5},\'{6}\') end",
                                    result["Driver"]["driverId"],
                                    results["MRData"]["RaceTable"]["Races"][0]["raceName"].ToString().Replace(" ", "") +
                                    results["MRData"]["RaceTable"]["Races"][0]["season"],
                                    result["position"],
                                    result["grid"],
                                    result["Time"] != null ? result["Time"]["time"] : "Retired",
                                    result["points"],
                                    result["status"]);

                                //Console.WriteLine(sql);
                                connection.Query(sql);
                            }
                        }
                    }
                }
                else
                {
                    var provas = connection.Query("select * from [LightsOut].[dbo].Prova where idEpoca = 2021").ToList();

                    foreach (var prova in provas)
                    {
                        JObject results = getJsonFromURL(String.Format("http://ergast.com/api/f1/2021/{0}/results.json", prova.ronda));
                        var corridas = results["MRData"]["RaceTable"]["Races"] as JArray;
                    
                        if (corridas.Count() != 0)
                        {
                            foreach (var result in results["MRData"]["RaceTable"]["Races"][0]["Results"].ToList())
                            {
                                var sql = String.Format(
                                    "If Not Exists(select * from [LightsOut].[dbo].Resultado where idPiloto = \'{0}\' and idProva = \'{1}\') begin insert into [LightsOut].[dbo].Resultado values (\'{1}\',\'{0}\',{2}, {3}, \'{4}\',{5},\'{6}\') end",
                                    result["Driver"]["driverId"],
                                    results["MRData"]["RaceTable"]["Races"][0]["raceName"].ToString().Replace(" ", "") +
                                    results["MRData"]["RaceTable"]["Races"][0]["season"],
                                    result["position"],
                                    result["grid"],
                                    result["Time"] != null ? result["Time"]["time"] : "Retired",
                                    result["points"],
                                    result["status"]);
                                
                                connection.Query(sql);
                            }
                        }
                    }
                    Console.WriteLine("Foram adicionados resultados mais recentes");
                }
            }
        }
        
        void loadQualificacao() {
            
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existeQualificacoes = "select * from [LightsOut].[dbo].Qualificacao;";
                var existeQualificacoesBD = connection.Query(existeQualificacoes);

                if (existeQualificacoesBD.Count() == 0)
                {
                    var provas = connection.Query("select * from [LightsOut].[dbo].Prova").ToList();

                    foreach (var prova in provas)
                    {
                        JObject qualificacoes = getJsonFromURL(String.Format("http://ergast.com/api/f1/{0}/{1}/qualifying.json",prova.idEpoca, prova.ronda));

                        var corridas = qualificacoes["MRData"]["RaceTable"]["Races"] as JArray;
                    
                        if (corridas.Count() != 0)
                        {
                            foreach (var qualificacao in qualificacoes["MRData"]["RaceTable"]["Races"][0][
                                "QualifyingResults"].ToList())
                            {
                                var sql = String.Format(
                                    "If Not Exists(select * from [LightsOut].[dbo].Qualificacao where idPiloto = \'{0}\' and idProva = \'{1}\') begin insert into [LightsOut].[dbo].Qualificacao values (\'{1}\',\'{0}\',{2}, \'{3}\', \'{4}\',\'{5}\') end",
                                    qualificacao["Driver"]["driverId"],
                                    qualificacoes["MRData"]["RaceTable"]["Races"][0]["raceName"].ToString()
                                        .Replace(" ", "") + qualificacoes["MRData"]["RaceTable"]["Races"][0]["season"],
                                    qualificacao["position"],
                                    qualificacao["Q1"] != null ? qualificacao["Q1"] : "Eliminated",
                                    qualificacao["Q2"] != null ? qualificacao["Q2"] : "Eliminated in Q1",
                                    qualificacao["Q3"] != null ? qualificacao["Q3"] : "Eliminated in Q2");

                                //Console.WriteLine(sql);
                                connection.Query(sql);
                            }
                        }
                    }
                }
                else
                {
                    var provas = connection.Query("select * from [LightsOut].[dbo].Prova where idEpoca = 2021").ToList();

                    foreach (var prova in provas)
                    {
                        JObject qualificacoes = getJsonFromURL(String.Format("http://ergast.com/api/f1/2021/{0}/qualifying.json", prova.ronda));

                        var corridas = qualificacoes["MRData"]["RaceTable"]["Races"] as JArray;
                    
                        if (corridas.Count() != 0)
                        {
                            foreach (var qualificacao in qualificacoes["MRData"]["RaceTable"]["Races"][0][
                                "QualifyingResults"].ToList())
                            {
                                var sql = String.Format(
                                    "If Not Exists(select * from [LightsOut].[dbo].Qualificacao where idPiloto = \'{0}\' and idProva = \'{1}\') begin insert into [LightsOut].[dbo].Qualificacao values (\'{1}\',\'{0}\',{2}, \'{3}\', \'{4}\',\'{5}\') end",
                                    qualificacao["Driver"]["driverId"],
                                    qualificacoes["MRData"]["RaceTable"]["Races"][0]["raceName"].ToString()
                                        .Replace(" ", "") + qualificacoes["MRData"]["RaceTable"]["Races"][0]["season"],
                                    qualificacao["position"],
                                    qualificacao["Q1"] != null ? qualificacao["Q1"] : "Eliminated",
                                    qualificacao["Q2"] != null ? qualificacao["Q2"] : "Eliminated in Q1",
                                    qualificacao["Q3"] != null ? qualificacao["Q3"] : "Eliminated in Q2");

                                //Console.WriteLine(sql);
                                connection.Query(sql);
                            }
                        }
                    }
                    Console.WriteLine("Foram adicionada  Qualificações mais recentes");
                }
            }
        }
        
        
        void loadCountries() {   
            
            List<Tuple<String, String>> countries = LoadJson("../../../Countries.json")
                .Select(x => new Tuple<String, String>(x["en_short_name"], x["nationality"]))
                    .ToList();

            
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                
                var existePaises = "select * from [LightsOut].[dbo].Pais;";
                var existePaisesBD = connection.Query(existePaises);

                if (existePaisesBD.Count() == 0)
                {
                    foreach (var country in countries)
                    {
                        var sql = String.Format("If Not Exists(select * from [LightsOut].[dbo].Pais where nome=\'{0}\') begin insert into [LightsOut].[dbo].Pais values (\'{0}\',\'{1}\') end",
                            country.Item1.Replace("'", "´"), country.Item2);
                        connection.Query(sql);
                    }
                }
                else
                {
                    Console.WriteLine("Não foi adicionado nenhum País!");
                }
            }
        }

        public List<Dictionary<String,String>> LoadJson(String path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Dictionary<String,String>>>(json);
            }
        }

        JObject getJsonFromURL(String url)
        {
            using (var w = new WebClient())
            {
                try
                {
                    return (JObject) JsonConvert.DeserializeObject(w.DownloadString(url));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error downloading info!");
                    return null;
                }
            }
        }


        public void ThreadCarregarDados()
        {
            DataManager dm = new DataManager();
            
            dm.loadCountries();
            dm.loadEpocas(2000,2021);
            dm.loadCircuitos();
            dm.loadProvas();
            dm.loadPilotos();
            dm.loadEquipas();
            dm.loadPilotosEquipas();
            dm.loadQualificacao(); //só aos sábados
            dm.loadResults();//só aos domingos
            
            Console.WriteLine("Terminou de executar");
            Thread.Sleep(86400000);//dormir 1 dia

        }
        
        
        static void Main(string[] args)
        {
            DataManager dm = new DataManager();

            while (true)//enquanto estiver a correr, vai metendo dados na Base de dados
            {
                Thread t1 = new Thread(dm.ThreadCarregarDados);
                t1.Start();
                t1.Join();
            }
        }
    }
}
