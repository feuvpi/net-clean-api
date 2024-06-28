using Application.Services;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class GrupoPartidaController : BaseController<GrupoPartida>
    {
        private readonly GrupoPartidaService _grupoPartidaService;

        public GrupoPartidaController(GrupoPartidaService grupoPartidaService) : base(grupoPartidaService)
        {
            _grupoPartidaService = grupoPartidaService;
        }

        // -- Add any additional functionality specific to the exameMedico entity here

    }
}
