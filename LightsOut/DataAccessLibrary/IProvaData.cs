using DataAccessLibrary.Models;
using System.Collections.Generic;

namespace DataAccessLibrary
{
    public interface IProvaData
    {
        List<LocalizacaoModel> GetLocalizacoes();
        List<LocalizacaoModel> GetProvas();
        List<LocalizacaoModel> GetProvasIntervalo(int ano, int ronda);
        List<ProvaModel> localizacaoProvasIntervalo(string dataInicial, string dataFinal);
        List<ProvaModel> ppppp(int ano, int ronda);
    }
}