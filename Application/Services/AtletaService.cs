using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class AtletaService : BaseService<Atleta>
    {
        private readonly IBaseRepository<Atleta> _atletaRepository;

        public AtletaService(IBaseRepository<Atleta> atletaRepository) : base(atletaRepository)
        {
            _atletaRepository = atletaRepository;
        }

        // Add any additional functionality specific to the Atleta entity here
        //public async Task<Atleta> GetByNomeAsync(string nome)
        //{
        //    return await _atletaRepository.GetByNomeAsync(nome);
        //}
    }
}
