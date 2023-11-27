using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PIM_4.Models
{
    public class Funcionario
    {
        public ObjectId _id { get; set; }
        public string IdFuncionario { get; set; }
        public string Nome {get;set;}

        public string Email { get;set;}

        public int CPF { get;set;}

        public string Cargo { get;set;} 

        public DateTime DataNascimento { get;set;}
    }
}
