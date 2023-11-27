using MongoDB.Bson;

namespace PIM_4.Models
{
    public class Pagamento
    {
        public string FormaDePagamento { get; set; }

        public double Valor { get;set; }

        public string Nome { get; set; }

        public string Comanda { get; set; }

        public string IdPagamento { get; set; }

        public ReservarQuarto ReservarQuarto { get; set; }
        public ObjectId _id { get; set; }

    }
}
