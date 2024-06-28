using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class PartidaAtletaRepository : BaseRepository<PartidaAtleta>
    {
        public PartidaAtletaRepository(DapperContext context) : base(context)
        {
        }

    }
}
