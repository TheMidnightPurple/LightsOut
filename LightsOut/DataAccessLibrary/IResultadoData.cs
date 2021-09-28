using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IResultadoData
    {
        Task<List<Tuple<string, int>>> ClassificacoesGeraisEquipas(int ano, int ronda);
        Task<List<Tuple<string, int>>> ClassificacoesGeraisPiloto(int ano, int ronda);
        List<LocalizacaoModel> GetLocalizacoes();
        List<LocalizacaoModel> GetProvas();
        List<LocalizacaoModel> GetProvasIntervalo(int ano, int ronda);
        List<ProvaModel> ppppp(int ano, int ronda);
        Task<List<List<string>>> ResultadosProva(string nomeProva);
    }
}