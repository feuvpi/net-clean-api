using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class PartidaRepository : BaseRepository<Partida>
    {
        public PartidaRepository(DapperContext context) : base(context)
        {
        }

    }
}
