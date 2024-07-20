using System.Text.Json.Serialization;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Application.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string? Salt
        {
            get { return Salt; }
            set { Salt = value; if (value != null) Password = HashPassword(Password, value); }
        }
        private string HashPassword(string password, string salt)
        {
            return BCryptNet.HashPassword(password, salt);
        }

    }
}
