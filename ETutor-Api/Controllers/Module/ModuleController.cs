using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Module
{
    [Route("api/module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleRepositoryAsync moduleRepositoryAsync;
        public ModuleController(IModuleRepositoryAsync moduleRepositoryAsync)
        {
            this.moduleRepositoryAsync = moduleRepositoryAsync;
        }

        #region SELECT

        [HttpGet]
        [Route("lecture/modules")]
        public async Task<IActionResult> Select_Modules_LectureId(int lectureId)
        {
            var modules = await moduleRepositoryAsync.Select_Module_LectureId(lectureId);

            if (null == modules || modules.Count < 1)
            {
                return BadRequest("No Modules Found");
            }
            else
            {
                return Ok(modules);
            }
        }

        [HttpGet]
        [Route("student/modules")]
        public async Task<IActionResult> Select_Modules_Student_Enrolled(int userId)
        {
            var modules = await moduleRepositoryAsync.Select_Modules_Student_Enrolled(userId);

            if (null == modules || modules.Count < 1)
            {
                return BadRequest("No Modules Found");
            }
            else
            {
                return Ok(modules);
            }
        }

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select_Modules()
        {
            var modules = await moduleRepositoryAsync.Select_Modules();

            if(null == modules || modules.Count < 1)
            {
                return BadRequest("No Modules Found");
            }
            else
            {
                return Ok(modules);
            }
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Insert(string name, string description, int lectureId, int courseId)
        {
            int user = await moduleRepositoryAsync.Insert(name, description, courseId, lectureId);

            return Ok(user);
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int moduleId)
        {
            int user = await moduleRepositoryAsync.Delete(moduleId);

            return Ok(user);
        }

        #endregion

        #region UPDATE

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(int moduleId, string name, string description, int lectureId, int courseId)
        {
            int user = await moduleRepositoryAsync.Update(moduleId, name, description, lectureId, courseId);

            return Ok(user);
        }

        #endregion
    }
}
