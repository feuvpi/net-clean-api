using System.Text.Json.Serialization;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Application.DTO
{
    public class RegisterDTO
    {
        public RegisterDTO()
        {
            Salt = BCrypt.Net.BCrypt.GenerateSalt();
        }
        private string? _password;
        public string Email { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
        public string Password
        {
            get { return _password; }
            set { _password = BCryptNet.HashPassword(value, Salt); }
        }

    }
}
