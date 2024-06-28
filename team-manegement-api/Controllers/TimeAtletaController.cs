using Application.Services;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class TimeAtletaController : BaseController<TimeAtleta>
    {
        private readonly TimeAtletaService _timeAtletaService;

        public TimeAtletaController(TimeAtletaService timeAtletaService) : base(timeAtletaService)
        {
            _timeAtletaService = timeAtletaService;
        }

        // -- Add any additional functionality specific to the TimeAtleta entity here

    }
}
