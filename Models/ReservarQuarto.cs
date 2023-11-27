using MongoDB.Bson;

namespace PIM_4.Models
{
    public class ReservarQuarto
    {
        public ObjectId _id { get; set; }
        public string IdQuarto { get; set; }
        public bool Disponibilidade { get; set; }

        public int NumeroQuarto { get; set; }

        public Double Valor { get; set; }

        public string TipoQuarto { get; set; }

        public bool ServicoQuarto { get; set; }

        public Pagamento Pagamento { get; set; }
    }
}
