using MongoDB.Bson;

namespace PIM_4.Models
{
    public class AreaComum
    {
        public ObjectId _id { get; set; }
        public string IdAreaComum{ get; set; }
        public string NomeAreaComum { get; set; }

        public int NumeroQuarto { get; set; }

        public double Valor { get; set; }

        public DateTime Horario { get; set; }

        public bool Reserva { get; set; }


       
            
        }
    }

