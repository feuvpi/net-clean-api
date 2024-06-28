using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class PartidaService : BaseService<Partida>
    {
        private readonly IBaseRepository<Partida> _partidaRepository;

        public PartidaService(IBaseRepository<Partida> partidaRepository) : base(partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        // -- Add any additional functionality specific to the Atleta entity here

    }
}
