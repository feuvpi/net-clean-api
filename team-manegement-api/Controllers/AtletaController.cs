using Microsoft.AspNetCore.Mvc;
using team_manegement_api.Core;

namespace team_manegement_api.Controllers
{
    public class AtletaController : BaseController<Atleta>
    {
        private readonly AtletaService _atletaService;

        public AtletaController(AtletaService atletaService) : base(atletaService)
        {
            _atletaService = atletaService;
        }

        // Add any additional functionality specific to the Atleta entity here
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<Atleta>> GetByNomeAsync(string nome)
        {
            var atleta = await _atletaService.GetByNomeAsync(nome);
            if (atleta == null)
            {
                return NotFound();
            }
            return Ok(atleta);
        }
    }
}
