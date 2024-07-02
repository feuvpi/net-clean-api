using System.ComponentModel.DataAnnotations.Schema;

namespace team_manegement_api.Core
{
    public class GrupoPartida : BaseModel
    {
        public string Nome {  get; set; }   
        public DateTime? Inicio { get; set; }    
        public DateTime? Fim { get; set; }
        [NotMapped]
        public List<Partida> Partidas { get; set; }

        public Guid TimeId { get; set; } // -- Id from Time is FK of GrupoPartida
        [NotMapped]
        public Time Time { get; set; }
    }
}
