namespace team_manegement_api.Core
{
    public class TimeAtleta : BaseModel
    {
        public Guid TimeId { get; set; }
        public int AtletaId { get; set; }

        // Additional properties if needed

        // Navigation properties if you want to represent relationships in code
        public Time Time { get; set; }
        public Atleta Atleta { get; set; }
    }
}
