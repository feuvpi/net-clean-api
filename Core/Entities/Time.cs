using System.ComponentModel.DataAnnotations.Schema;

namespace team_manegement_api.Core
{
    public class Time : BaseModel
    {
        public string Nome { get; set; }
        public int IdadeLimite { get; set; }
        [NotMapped]
        public List<Atleta> Atletas { get; set; }
        [NotMapped]
        public List<Partida> Partidas { get; set; }
    }
}
