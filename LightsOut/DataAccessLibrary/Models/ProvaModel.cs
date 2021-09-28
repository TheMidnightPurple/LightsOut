using System;

namespace DataAccessLibrary.Models
{
    public class ProvaModel
    {
        public string id { get; set; }

        public int idEpoca { get; set; }

        public int ronda { get; set; }

        public string nomeProva { get; set; }

        public DateTime data { get; set; }

        public LocalizacaoModel localizacao { get; set; }

        public ProvaModel(string id, int idEpoca, int ronda, string nomeProva, DateTime data,
            LocalizacaoModel localizacao)
        {
            this.id = id;
            this.idEpoca = idEpoca;
            this.ronda = ronda;
            this.nomeProva = nomeProva;
            this.data = data;
            this.localizacao = localizacao;
        }

        public ProvaModel()
        {
            this.id = "";
            this.idEpoca = 0;
            this.ronda = 0;
            this.nomeProva = "";
            this.data = DateTime.Now;
            this.localizacao = null;
        }
    }
}