using System.Reflection.Metadata;

namespace team_manegement_api.Core
{
    public class ExameMedico : BaseModel
    {
        public string Descricao { get; set; }
        public Atleta Atleta { get; set; }  
        public DateTime Data { get; set; }
        public string Observacoes { get; set; } 
        public Byte[] Anexo { get; set; }   
        public string DocumentUrl { get; set; } 

    }
}
