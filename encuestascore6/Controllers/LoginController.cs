using Logic.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiEncuesta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ISessionLogic _sessionLogic;

        public LoginController(
            ILogger<LoginController> logger,
            ISessionLogic sessionLogic)
        {
            _logger = logger;
            _sessionLogic = sessionLogic;
        }

        [AllowAnonymous]
        [HttpPost]
        public LoginResponse Login(LoginRequest user)
        {
            return _sessionLogic.Login(user);
        }
    }
}
