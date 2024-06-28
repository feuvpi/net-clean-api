using Application.Services;
using Core.Entities;

namespace team_manegement_api.Controllers
{
    public class UsuarioController : BaseController<Usuario>
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // -- Add any additional functionality specific to the Usuario entity here

    }
}
