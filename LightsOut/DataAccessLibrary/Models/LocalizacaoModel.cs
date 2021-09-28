using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public class LocalizacaoModel
    {
        public string id {get; set;}

        public string nome{ get; set; }

        public string nacionalidade{ get; set;}

        public float latitude{ get; set;}

        public float longitude{ get; set;} 

        public LocalizacaoModel(string id, string nome, string nacionalidade, float latitude, float longitude){
            this.id = id;
            this.nome = nome;
            this.nacionalidade = nacionalidade;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        
        public LocalizacaoModel(){
            this.id = "";
            this.nome = "";
            this.nacionalidade = "";
            this.latitude = 0;
            this.longitude = 0;
        }
    }
}