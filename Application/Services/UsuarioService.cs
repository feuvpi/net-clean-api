using Application.DTO;
using Application.Utils;
using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UsuarioService : BaseService<Usuario>
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Add any additional functionality specific to the Atleta entity here
        public async Task<SessionDTO> Login(LoginDTO credentials, JwtSettings _jwtSettings)
        {
            // -- retrieve user and authenticat
            var user = await _usuarioRepository.GetByEmailAsync(credentials.Email);
            if (user == null) throw new Exception("Invalid credentials.");
            credentials.Salt = user.Salt;
            if (credentials.Password != user.Password) throw new Exception("Invalid credentials.");

            // -- generate 
            var token = GenerateToken(user, _jwtSettings);

            var response = new SessionDTO
            {
                Token = token,
                Role = user.Funcao,
                Id = user.Id
            };

            return response;
        }

        public async Task<SessionDTO> CreateUserAsync(RegisterDTO userDTO, JwtSettings jwtSettings)
        {
            try
            {
                // -- email checkc
                var user = await _usuarioRepository.GetByEmailAsync(userDTO.Email);
                if (user != null) throw new Exception("Email already in use.");

                // -- create new user
                Usuario createUser = new Usuario(userDTO.Email, userDTO.Password, userDTO.Salt);
                var createdUser = await _usuarioRepository.AddAsync(createUser);

                if (createdUser == null) throw new Exception("Database is unavailable. Please contact support.");
                createUser.Id = createdUser.Id;

                // -- Uma colecao apenas, Usuario, que tera dentro dele o objeto condomino/condominio
                var token = GenerateToken(createUser, jwtSettings);


                var response = new SessionDTO
                {
                    Token = token,
                    Role = createUser.Funcao,
                    Id = createUser.Id
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GenerateToken(Usuario user, JwtSettings _jwtSettings)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Actor, user.Funcao.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpireInMinutes),
                SigningCredentials = credentials,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        public async Task<Usuario?> ValidateTokenAndRetrieveUser(string token, JwtSettings _jwtSettings)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidAudience = _jwtSettings.Audience,
                };

                var principal = tokenHandler.ValidateToken(token, validationParams, out SecurityToken validatedToken);
                var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value);
                var funcao = principal.FindFirst(ClaimTypes.Actor).Value;

                return new Usuario { Id = userId, Funcao = funcao };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
