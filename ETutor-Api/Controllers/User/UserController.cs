using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryAsync userRepositoryAsync;
        public UserController(IUserRepositoryAsync userRepositoryAsync)
        {
            this.userRepositoryAsync = userRepositoryAsync;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await userRepositoryAsync.Select(username, password);

            if (null == user)
            {
                return BadRequest("Incorrect login details");
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
