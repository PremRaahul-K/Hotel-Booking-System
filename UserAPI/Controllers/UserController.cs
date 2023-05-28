using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models.DTO;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> Register([FromBody] UserRegisterDTO userDTO)
        {
            var user = _userService.Register(userDTO);
            if (user == null)
            {
                return BadRequest("Unable to register");
            }
            return Created("Home", user);
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> Login([FromBody] UserDTO userDTO)
        {
            var user = _userService.Login(userDTO);
            if (user == null)
            {
                return BadRequest("invalid username or password");
            }
            return Ok(user);
        }
    }
}
