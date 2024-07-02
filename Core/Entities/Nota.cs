
using System.ComponentModel.DataAnnotations.Schema;

namespace team_manegement_api.Core
{
    public class Nota : BaseModel
    {
        public int Valor { get; set; } // -- Find a way to limit it, it can be only 0-10
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public Guid AtletaId { get; set; } // Id from Atleta is FK of Nota
        [NotMapped]
        public Atleta Atleta { get; set; }  
    }
}
