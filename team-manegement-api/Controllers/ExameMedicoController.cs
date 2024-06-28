using Application.Services;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class ExameMedicoController : BaseController<ExameMedico>
    {
        private readonly ExameMedicoService _exameMedicoService;

        public ExameMedicoController(ExameMedicoService exameMedicoService) : base(exameMedicoService)
        {
            _exameMedicoService = exameMedicoService;
        }

        // -- Add any additional functionality specific to the exameMedico entity here

    }
}
