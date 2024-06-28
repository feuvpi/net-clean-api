using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(DapperContext context) : base(context)
        {
        }

    }
}
