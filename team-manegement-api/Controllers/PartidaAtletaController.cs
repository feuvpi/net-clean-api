using Application.Services;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class PartidaAtletaController : BaseController<PartidaAtleta>
    {
        private readonly PartidaAtletaService _partidaAtletaService;

        public PartidaAtletaController(PartidaAtletaService partidaAtletaService) : base(partidaAtletaService)
        {
            _partidaAtletaService = partidaAtletaService;
        }

        // -- Add any additional functionality specific to the PartidaAtleta entity here

    }
}
