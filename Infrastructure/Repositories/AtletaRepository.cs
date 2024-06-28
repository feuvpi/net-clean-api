using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class AtletaRepository : BaseRepository<Atleta>
    {
        public AtletaRepository(DapperContext context) : base(context)
        {
        }

    }
}
