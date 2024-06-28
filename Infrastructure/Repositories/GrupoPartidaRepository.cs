using Infrastructure.Data;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class GrupoPartidaRepository : BaseRepository<GrupoPartida>
    {
        public GrupoPartidaRepository(DapperContext context) : base(context)
        {
        }

    }
}
