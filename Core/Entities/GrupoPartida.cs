namespace team_manegement_api.Core
{
    public class GrupoPartida : BaseModel
    {
        public string Nome {  get; set; }   
        public DateTime? Inicio { get; set; }    
        public DateTime? Fim { get; set; }
        public List<Partida> Partidas { get; set; }

    }
}
