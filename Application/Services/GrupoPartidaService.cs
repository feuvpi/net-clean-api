using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class GrupoPartidaService : BaseService<GrupoPartida>
    {
        private readonly IBaseRepository<GrupoPartida> _grupoPartidaRepository;

        public GrupoPartidaService(IBaseRepository<GrupoPartida> grupoPartidaRepository) : base(grupoPartidaRepository)
        {
            _grupoPartidaRepository = grupoPartidaRepository;
        }

        // -- Add any additional functionality specific to the Atleta entity here

    }
}
