using DataAccessLibrary.Models;
using System.Collections.Generic;

namespace DataAccessLibrary
{
    public interface ILocalizacaoData
    {
        List<LocalizacaoModel> GetLocalizacoes();
    }
}