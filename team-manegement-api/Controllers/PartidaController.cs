using Application.Services;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class PartidaController : BaseController<Partida>
    {
        private readonly PartidaService _partidaService;

        public PartidaController(PartidaService partidaService) : base(partidaService)
        {
            _partidaService = partidaService;
        }

        // -- Add any additional functionality specific to the Partida entity here

    }
}
