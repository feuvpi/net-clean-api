using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace team_manegement_api.Core
{
    public class ExameMedico : BaseModel
    {
        public string Descricao { get; set; }
        public int AtletaId { get; set; } // -- Id from Atleta is FK of ExameMedico
        [NotMapped]
        public Atleta Atleta { get; set; }  
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        [NotMapped]
        public Byte[] Anexo { get; set; }   
        public string DocumentUrl { get; set; } 

    }
}
