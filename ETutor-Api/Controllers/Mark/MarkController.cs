using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Mark
{
    [Route("api/marks")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkRepositoryAsync markRepositoryAsync;
        public MarkController(IMarkRepositoryAsync markRepositoryAsync)
        {
            this.markRepositoryAsync = markRepositoryAsync;
        }

        #region POST

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Register(int mark, int moduleId, int userId)
        {
            int marks = await markRepositoryAsync.Insert(mark, moduleId, userId);

            return Ok(marks);
        }

        #endregion

        [HttpGet]
        [Route("student/marks")]
        public async Task<IActionResult> Select_Marks(int studentId)
        {
            var marks = await markRepositoryAsync.Select_Marks(studentId);

            if (null == marks || marks.Count < 1)
            {
                return BadRequest("No Marks Found");
            }
            else
            {
                return Ok(marks);
            }
        }
    }
}
