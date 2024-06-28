namespace team_manegement_api.Core
{
    public class PartidaAtleta : BaseModel
    {
        public Atleta Atleta { get; set; }
        public Partida Partida { get; set; }
        public int Minutagem { get; set; }
        public int CartoesAmarelos { get;set; }
        public int CartaoVermelho { get; set; }
        public int Gols { get; set; }
        public List<Partida> Partidas { get; set; }

    }
}
