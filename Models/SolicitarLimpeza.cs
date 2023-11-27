using MongoDB.Bson;

namespace PIM_4.Models
{
    public class SolicitarLimpeza
    {
        public ObjectId _id { get; set; }
        public string IdLimpeza { get; set; }
        public string NomeFuncionario { get; set; }

        public int Quarto { get; set; }

        public string TipoLimpeza { get; set; }

        public DateTime TempoLimpeza { get; set; }

        public bool Finalizado { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
