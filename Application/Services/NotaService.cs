using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class NotaService : BaseService<Nota>
    {
        private readonly IBaseRepository<Nota> _notaRepository;

        public NotaService(IBaseRepository<Nota> notaRepository) : base(notaRepository)
        {
            _notaRepository = notaRepository;
        }

        // Add any additional functionality specific to the Atleta entity here
        //public async Task<Atleta> GetByNomeAsync(string nome)
        //{
        //    return await _atletaRepository.GetByNomeAsync(nome);
        //}
    }
}
