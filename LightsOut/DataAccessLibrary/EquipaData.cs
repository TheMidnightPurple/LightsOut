using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using Dapper;

namespace DataAccessLibrary
{
    public class EquipaData : IEquipaData
    {
        public string conString =
            "Data Source=(local);Initial Catalog=LightsOut;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Task<List<EquipaModel>> GetEquipasEpoca(int ano)
        {
            Dictionary<string, List<string>> equipas = new Dictionary<string, List<string>>();//equipa e lista pilotos
            //List<Equipa> equipas = new List<Equipa>();

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();

                string procuraEquipas =
                    String.Format( //lista com nome do piloto e pontos obtidos numa prova(várias provas)
                        "Select E.nome, E.nacionalidade, P.nome as nomePiloto from [LightsOut].[dbo].Equipa E join PilotoEquipa Pe on Pe.idEquipa = E.id join Piloto P on Pe.idPiloto = P.id where Pe.idEpoca = {0};",
                        ano);

                //Console.WriteLine(procuraResultados);
                var results = connection.Query(procuraEquipas);

                foreach (var equipa in results)
                {

                    if (equipas.ContainsKey(equipa.nome))
                    {
                        //nome já existe
                        List<string> pilotos = equipas[equipa.nome];
                        pilotos.Add(equipa.nomePiloto);
                        equipas[equipa.nome] = pilotos;

                    }
                    else
                    {
                        //nome ainda não existe
                        List<string> pilotos = new List<string>();
                        pilotos.Add(equipa.nomePiloto);
                        pilotos.Add(equipa.nacionalidade);//meter a nacionalidade na lista para não a perder
                        equipas[equipa.nome] = pilotos;
                    }
                }

                List<EquipaModel> equipasDaEpoca = new List<EquipaModel>();

                foreach (KeyValuePair<string, List<string>> entry in equipas)
                {
                    List<string> info = entry.Value;
                    string nacionalidade = info[1];
                    List<string> ps = new List<string>();
                    ps.Add(info[0]);
                    ps.Add(info[2]);
                    EquipaModel e = new EquipaModel(entry.Key, nacionalidade, ps);
                    equipasDaEpoca.Add(e);
                }

                return Task.FromResult(equipasDaEpoca);
            }
        }
    }
}