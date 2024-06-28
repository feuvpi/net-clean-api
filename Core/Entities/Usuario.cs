using team_manegement_api.Core;

namespace Core.Entities
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Funcao { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
