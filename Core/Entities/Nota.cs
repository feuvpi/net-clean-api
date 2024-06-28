
namespace team_manegement_api.Core
{
    public class Nota : BaseModel
    {
        public int Valor { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public Guid AtletaId { get; set; }
        public Atleta Atleta { get; set; }  
    }
}
