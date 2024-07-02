
using System.ComponentModel.DataAnnotations.Schema;

namespace team_manegement_api.Core
{
    public class Partida : BaseModel
    {
        public Guid TimeId { get; set; }
        [NotMapped]
        public Time Time { get; set; }  
        public Guid GrupoPartidaId { get; set; } // -- Id from GrupoPartida is FK of Partida
        [NotMapped]
        public GrupoPartida GrupoPartida { get; set; }
        public string TimeAdversario { get; set; }
        public DateTime DataHorario { get; set; }
        public string Local {  get; set; }
        [NotMapped]
        public List<Atleta> JogadoresRelacionados { get; set; }
        public int GolsAFavor { get; set; }
        public int GolsContra { get; set; }   
    }
}
