using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public class EquipaModel
    {
        public string nome { get; set; }

        public string nacionalidade { get; set; }

        public List<string> pilotos { get; set; }

        public EquipaModel()
        {
            this.nome = "";
            this.nacionalidade = "";
            this.pilotos = new List<string>();
        }
        public EquipaModel(string nome, string nacionalidade, List<string> pilotos)
        {
            this.nome = nome;
            this.nacionalidade = nacionalidade;
            this.pilotos = pilotos;
        }
    }
}