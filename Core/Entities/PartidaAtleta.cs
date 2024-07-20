using System.ComponentModel.DataAnnotations.Schema;

namespace team_manegement_api.Core
{
    public class PartidaAtleta : BaseModel
    {
        // -- Id from Atleta is a FK of PartidaAtleta
        public int AtletaId { get; set; }
        [NotMapped]
        public Atleta Atleta { get; set; }
        // -- Id from Partida is a FK of PartidaAtleta
        public int PartidaId { get; set; }
        [NotMapped]
        public Partida Partida { get; set; }
        public int Minutagem { get; set; }
        public int CartoesAmarelos { get;set; }
        public int CartaoVermelho { get; set; }
        public int Gols { get; set; }

    }
}
