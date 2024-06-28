using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class TimeAtletaService : BaseService<TimeAtleta>
    {
        private readonly IBaseRepository<TimeAtleta> _timeAtletaRepository;

        public TimeAtletaService(IBaseRepository<TimeAtleta> timeAtletaRepository) : base(timeAtletaRepository)
        {
            _timeAtletaRepository = timeAtletaRepository;
        }

        // Add any additional functionality specific to the Atleta entity here
        //public async Task<Atleta> GetByNomeAsync(string nome)
        //{
        //    return await _atletaRepository.GetByNomeAsync(nome);
        //}
    }
}
