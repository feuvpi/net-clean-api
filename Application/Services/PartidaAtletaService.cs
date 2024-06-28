using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class PartidaAtletaService : BaseService<PartidaAtleta>
    {
        private readonly IBaseRepository<PartidaAtleta> _partidaAtletaRepository;

        public PartidaAtletaService(IBaseRepository<PartidaAtleta> partidaAtletaRepository) : base(partidaAtletaRepository)
        {
            _partidaAtletaRepository = partidaAtletaRepository;
        }

        // -- Add any additional functionality specific to the Atleta entity here

    }
}
