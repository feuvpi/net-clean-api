using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class TimeService : BaseService<Time>
    {
        private readonly IBaseRepository<Time> _timeRepository;

        public TimeService(IBaseRepository<Time> timeRepository) : base(timeRepository)
        {
            _timeRepository = timeRepository;
        }

        // Add any additional functionality specific to the Atleta entity here
        //public async Task<Atleta> GetByNomeAsync(string nome)
        //{
        //    return await _atletaRepository.GetByNomeAsync(nome);
        //}
    }
}
