using MongoDB.Driver;
using PIM_4.Models;

namespace PIM_4.Dao
{
    public class ReservarQuartoDao : BancoDao
    {
        public ReservarQuarto ObterQuarto(string id)
        {
            var filtro = Builders<ReservarQuarto>.Filter.Where(s => s.IdQuarto == id);
            var tabela = database.GetCollection<ReservarQuarto>("reservaquarto");

            return tabela.Find(filtro).FirstOrDefault();
        }

        public List<ReservarQuarto> ObterReserva()
        {
            var filtro = Builders<ReservarQuarto>.Filter.Where(s => s.IdQuarto != null);
            var tabela = database.GetCollection<ReservarQuarto>("reservaquarto");

            return tabela.Find(filtro).ToList();
        }

        public void CriarReserva(ReservarQuarto reservarQuarto)
        {
            var tabela = database.GetCollection<ReservarQuarto>("reservaquarto");

            tabela.InsertOne(reservarQuarto);
        }

        public void AtualizarReserva(ReservarQuarto reservarQuarto)
        {
            var filtro = Builders<ReservarQuarto>.Filter.Where(s => s.IdQuarto == reservarQuarto.IdQuarto);
            var tabela = database.GetCollection<ReservarQuarto>("reservaquarto");

            var update = Builders<ReservarQuarto>.Update
                .Set(s => s.Disponibilidade, reservarQuarto.Disponibilidade)
                .Set(s => s.NumeroQuarto, reservarQuarto.NumeroQuarto)
                .Set(s => s.Valor, reservarQuarto.Valor)
                .Set(s => s.TipoQuarto, reservarQuarto.TipoQuarto)
                .Set(s => s.ServicoQuarto, reservarQuarto.ServicoQuarto);

            var result = tabela.UpdateOne(filtro, update);
        }

        public void ExcluirReserva(ReservarQuarto reservarQuarto)
        {
            var tabela = database.GetCollection<ReservarQuarto>("reservaquarto");
            var filtro = Builders<ReservarQuarto>.Filter.Where(s => s.IdQuarto == reservarQuarto.IdQuarto);

            tabela.DeleteOne(filtro);
        }
    }
}
