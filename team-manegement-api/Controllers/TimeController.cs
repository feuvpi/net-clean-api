using Application.Services;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class TimeController : BaseController<Time>
    {
        private readonly TimeService _timeService;

        public TimeController(TimeService timeService) : base(timeService)
        {
            _timeService = timeService;
        }

        // -- Add any additional functionality specific to the Time entity here

    }
}
