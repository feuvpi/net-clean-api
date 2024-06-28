using Application.Services;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class NotaController : BaseController<Nota>
    {
        private readonly NotaService _atletaService;

        public NotaController(NotaService notaService) : base(notaService)
        {
            _atletaService = notaService;
        }

        // -- Add any additional functionality specific to the Atleta entity here

    }
}
