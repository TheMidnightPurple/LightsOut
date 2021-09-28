namespace DataAccessLibrary.Models
{
    public class ResultadoModel
    {
        public string id {get; set;}

        public ProvaModel prova{ get; set; }

        public PilotoModel piloto{ get; set;}

        public int posicaoFinal{ get; set;}

        public int posicaoInicial{ get; set;}

        public string tempo{ get; set;} 

        public int pontos{ get; set;}

        public string estado{ get; set;}

        public ResultadoModel(string id, ProvaModel prova, PilotoModel piloto, int posicaoFinal, int posicaoInicial, string tempo, int pontos, string estado)
        {
            this.id = id;
            this.prova = prova;
            this.piloto = piloto;
            this.posicaoFinal = posicaoFinal;
            this.posicaoInicial = posicaoInicial;
            this.tempo = tempo;
            this.pontos = pontos;
            this.estado = estado;
        }

        public ResultadoModel()
        {
            this.id = "";
            this.prova = null;
            this.piloto = null;
            this.posicaoFinal = 0;
            this.posicaoInicial = 0;
            this.tempo = "";
            this.pontos = 0;
            this.estado = "";
        }
    }
}