
namespace team_manegement_api.Core
{
    public class Partida : BaseModel
    {
        public Time Time { get; set; }  
        public string TimeAdversario { get; set; }
        public DateTime DataHorario { get; set; }
        public string Local {  get; set; }  
        public List<Atleta> JogadoresRelacionados { get; set; }
        public int GolsAFavor { get; set; }
        public int GolsContra { get; set; }   
    }
}
