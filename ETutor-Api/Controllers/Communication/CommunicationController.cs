using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Communication
{
    [Route("api/message")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationRepositoryAsync communicationRepositoryAsync;
        public CommunicationController(ICommunicationRepositoryAsync communicationRepositoryAsync)
        {
            this.communicationRepositoryAsync = communicationRepositoryAsync;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Insert(string message, int moduleId, int userId)
        {
            int post = await communicationRepositoryAsync.Insert(message, moduleId, userId);

            return Ok(post);
        }

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select_Messages(int moduleId)
        {
            var messages = await communicationRepositoryAsync.Select(moduleId);

            if (null == messages || messages.Count < 1)
            {
                return BadRequest("No Messages Found");
            }
            else
            {
                return Ok(messages);
            }
        }
    }
}
