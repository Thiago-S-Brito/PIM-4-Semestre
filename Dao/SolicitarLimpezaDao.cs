using MongoDB.Driver;
using PIM_4.Models;

namespace PIM_4.Dao
{
    public class SolicitarLimpezaDao : BancoDao
    {
        public SolicitarLimpeza ObterLimpeza(string id)
        {
            var filtro = Builders<SolicitarLimpeza>.Filter.Where(s => s.IdLimpeza == id);
            var tabela = database.GetCollection<SolicitarLimpeza>("solicitarlimpeza");

            return tabela.Find(filtro).FirstOrDefault();
        }

        public List<SolicitarLimpeza> ObterLimpeza()
        {
            var filtro = Builders<SolicitarLimpeza>.Filter.Where(s => s.IdLimpeza != null);
            var tabela = database.GetCollection<SolicitarLimpeza>("solicitarlimpeza");

            return tabela.Find(filtro).ToList();
        }

        public void CriarLimpeza(SolicitarLimpeza solicitarLimpeza)
        {
            var tabela = database.GetCollection<SolicitarLimpeza>("solicitarlimpeza");

            tabela.InsertOne(solicitarLimpeza);
        }

        public void AtualizarLimpeza(SolicitarLimpeza solicitarLimpeza)
        {
            var filtro = Builders<SolicitarLimpeza>.Filter.Where(s => s.IdLimpeza == solicitarLimpeza.IdLimpeza);
            var tabela = database.GetCollection<SolicitarLimpeza>("solicitarlimpeza");

            var update = Builders<SolicitarLimpeza>.Update
                .Set(s => s.NomeFuncionario, solicitarLimpeza.NomeFuncionario)
                .Set(s => s.Quarto, solicitarLimpeza.Quarto)
                .Set(s => s.TipoLimpeza, solicitarLimpeza.TipoLimpeza)
                .Set(s => s.TempoLimpeza, solicitarLimpeza.TempoLimpeza)
                .Set(s => s.Finalizado, solicitarLimpeza.Finalizado);

            var result = tabela.UpdateOne(filtro, update);
        }

        public void ExcluirLimpeza(SolicitarLimpeza solicitarLimpeza)
        {
            var tabela = database.GetCollection<SolicitarLimpeza>("solicitarlimpeza");
            var filtro = Builders<SolicitarLimpeza>.Filter.Where(s => s.IdLimpeza == solicitarLimpeza.IdLimpeza);

            tabela.DeleteOne(filtro);
        }
    }
}
