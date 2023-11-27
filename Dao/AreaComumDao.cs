using MongoDB.Driver;
using PIM_4.Models;

namespace PIM_4.Dao
{
    public class AreaComumDao : BancoDao
    {
        public AreaComum ObterAreaComum(string id)
        {
            var filtro = Builders<AreaComum>.Filter.Where(s => s.IdAreaComum == id);
            var tabela = database.GetCollection<AreaComum>("areacomum");

            return tabela.Find(filtro).FirstOrDefault();
        }

        public List<AreaComum> ObterAreaComum()
        {
            var filtro = Builders<AreaComum>.Filter.Where(s => s.NomeAreaComum != null);
            var tabela = database.GetCollection<AreaComum>("areacomum");

            return tabela.Find(filtro).ToList();
        }

        public void CriarAreaComum(AreaComum areaComum)
        {
            var tabela = database.GetCollection<AreaComum>("areacomum");

            tabela.InsertOne(areaComum);
        }

        public void AtualizarAreaComum(AreaComum areaComum)
        {
            var filtro = Builders<AreaComum>.Filter.Where(s => s.IdAreaComum == areaComum.IdAreaComum);
            var tabela = database.GetCollection<AreaComum>("areacomum");

            var update = Builders<AreaComum>.Update
                .Set(s => s.NomeAreaComum, areaComum.NomeAreaComum)
                .Set(s => s.NumeroQuarto, areaComum.NumeroQuarto)
                .Set(s => s.Valor, areaComum.Valor)
                .Set(s => s.Horario, areaComum.Horario)
                .Set(s => s.Reserva, areaComum.Reserva);

            var result = tabela.UpdateOne(filtro, update);
        }

        public void ExcluirAreaComum(AreaComum areaComum)
        {
            var tabela = database.GetCollection<AreaComum>("areacomum");
            var filtro = Builders<AreaComum>.Filter.Where(s => s.IdAreaComum == areaComum.IdAreaComum);

            tabela.DeleteOne(filtro);
        }
    }
}
