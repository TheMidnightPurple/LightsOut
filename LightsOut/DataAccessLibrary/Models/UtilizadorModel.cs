namespace DataAccessLibrary.Models
{
    public class UtilizadorModel
    {
        public string username;

        public string password;
        
        //adicionar lista notificações

        public UtilizadorModel()
        {
            this.username = "";
            this.password = "";
        }

        public UtilizadorModel(string utilizador, string password)
        {
            this.username = utilizador;
            this.password = password;
        }
    }
}