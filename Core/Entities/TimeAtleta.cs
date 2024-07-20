using System.ComponentModel.DataAnnotations.Schema;

namespace team_manegement_api.Core
{
    public class TimeAtleta : BaseModel
    {
        public int TimeId { get; set; } // Id from Time is FK of TimeAtleta
        public int AtletaId { get; set; } // Id from Atleta is FK of TimeAtleta

        public DateTime DataAssociacao { get; set; }

        // Additional properties if needed

        // Navigation properties if you want to represent relationships in code
        [NotMapped]
        public Time Time { get; set; }
        [NotMapped]
        public Atleta Atleta { get; set; }
    }
}
