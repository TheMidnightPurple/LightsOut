using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface INotificacaoData
    {
        Task<string> AddNotificacao(string nomeUtilizador, string idProva);
        Task<string> sendNotification(string nomeUtilizador);
    }
}