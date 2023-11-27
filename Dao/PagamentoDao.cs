using MongoDB.Driver;
using PIM_4.Models;

namespace PIM_4.Dao
{
    public class PagamentoDao : BancoDao
    {
        public Pagamento ObterPagamento(string id)
        {
            var filtro = Builders<Pagamento>.Filter.Where(s => s.IdPagamento == id);
            var tabela = database.GetCollection<Pagamento>("pagamentos");

            return tabela.Find(filtro).FirstOrDefault();
        }

        public List<Pagamento> ObterPagamento()
        {
            var filtro = Builders<Pagamento>.Filter.Where(s => s.Nome != null);
            var tabela = database.GetCollection<Pagamento>("pagamentos");

            return tabela.Find(filtro).ToList();
        }

        public void CriarPagamento(Pagamento pagamento)
        {
            var tabela = database.GetCollection<Pagamento>("pagamentos");

            tabela.InsertOne(pagamento);
        }

        public void AtualizarPagamento(Pagamento pagamento)
        {
            var filtro = Builders<Pagamento>.Filter.Where(s => s.IdPagamento == pagamento.IdPagamento);
            var tabela = database.GetCollection<Pagamento>("pagamentos");

            var update = Builders<Pagamento>.Update
                .Set(s => s.FormaDePagamento, pagamento.FormaDePagamento)
                .Set(s => s.Valor, pagamento.Valor)
                .Set(s => s.Nome, pagamento.Nome)
                .Set(s => s.Comanda, pagamento.Comanda);

            var result = tabela.UpdateOne(filtro, update);
        }

        public void ExcluirPagamento(Pagamento pagamento)
        {
            var tabela = database.GetCollection<Pagamento>("pagamentos");
            var filtro = Builders<Pagamento>.Filter.Where(s => s.IdPagamento == pagamento.IdPagamento);

            tabela.DeleteOne(filtro);
        }
    }
}
