using MongoDB.Bson;
using MongoDB.Driver;
using PIM_4.Models;

namespace PIM_4.Dao
{
    public class FuncionarioDao : BancoDao
    {
        public Funcionario ObterFuncionario(string id)
        {
            var filtro = Builders<Funcionario>.Filter.Where(s => s.IdFuncionario == id);
            var tabela = database.GetCollection<Funcionario>("funcionarios");

            return tabela.Find(filtro).FirstOrDefault();
        }

        public List<Funcionario> ObterFuncionarios()
        {
            var filtro = Builders<Funcionario>.Filter.Where(s => s.Nome != null);
            var tabela = database.GetCollection<Funcionario>("funcionarios");

            return tabela.Find(filtro).ToList();
        }

        public void CriarFuncionario(Funcionario funcionario)
        {
            var tabela = database.GetCollection<Funcionario>("funcionarios");

            tabela.InsertOne(funcionario);
        }

        public void AtualizarFuncionario(Funcionario funcionario)
        {
            var filtro = Builders<Funcionario>.Filter.Where(s => s.IdFuncionario == funcionario.IdFuncionario);
            var tabela = database.GetCollection<Funcionario>("funcionarios");

            var update = Builders<Funcionario>.Update
                .Set(s => s.DataNascimento, funcionario.DataNascimento)
                .Set(s => s.Email, funcionario.Email)
                .Set(s => s.Cargo, funcionario.Cargo)
                .Set(s => s.CPF, funcionario.CPF)
                .Set(s => s.Nome, funcionario.Nome);

            var result = tabela.UpdateOne(filtro, update);
        }

        public void ExcluirFuncionario(Funcionario funcionario)
        {
            var tabela = database.GetCollection<Funcionario>("funcionarios");
            var filtro = Builders<Funcionario>.Filter.Where(s => s.IdFuncionario == funcionario.IdFuncionario);

            tabela.DeleteOne(filtro);
        }
    }
}
