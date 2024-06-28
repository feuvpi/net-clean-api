using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class UsuarioService : BaseService<Usuario>
    {
        private readonly IBaseRepository<Usuario> _usuarioRepository;

        public UsuarioService(IBaseRepository<Usuario> usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Add any additional functionality specific to the Atleta entity here
        //public async Task<Atleta> GetByNomeAsync(string nome)
        //{
        //    return await _atletaRepository.GetByNomeAsync(nome);
        //}
    }
}
