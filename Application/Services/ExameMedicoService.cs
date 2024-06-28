using Core.Interfaces;
using team_manegement_api.Core;

namespace Application.Services
{
    public class ExameMedicoService : BaseService<ExameMedico>
    {
        private readonly IBaseRepository<ExameMedico> _exameMedicoRepository;

        public ExameMedicoService(IBaseRepository<ExameMedico> exameMedicoRepository) : base(exameMedicoRepository)
        {
            _exameMedicoRepository = exameMedicoRepository;
        }

        // -- Add any additional functionality specific to the Atleta entity here

    }
}
