using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.LoginHistory
{
    [Route("api/loginhistory")]
    [ApiController]
    public class LoginHistoryController : ControllerBase
    {
        private readonly ILoginHistoryRepositoryAsync loginHistoryRepositoryAsync;
        public LoginHistoryController(ILoginHistoryRepositoryAsync loginHistoryRepositoryAsync)
        {
            this.loginHistoryRepositoryAsync = loginHistoryRepositoryAsync;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> LogHistory(int userId, string ip)
        {
            int history = await loginHistoryRepositoryAsync.Insert(userId, ip);

            return Ok(history);
        }

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select()
        {
            var history = await loginHistoryRepositoryAsync.Select();

            if (null == history || history.Count < 1)
            {
                return BadRequest("No History Found");
            }
            else
            {
                return Ok(history);
            }
        }
    }
}
