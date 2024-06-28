namespace team_manegement_api.Core
{
    public class Time : BaseModel
    {
        public string Nome { get; set; }
        public int IdadeLimite { get; set; }
        public List<Atleta> Atletas { get; set; }
    }
}
