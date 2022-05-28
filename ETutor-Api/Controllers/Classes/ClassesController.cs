using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Classes
{
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesRepositoryAsync classesRepositoryAsync;
        public ClassesController(IClassesRepositoryAsync classesRepositoryAsync)
        {
            this.classesRepositoryAsync = classesRepositoryAsync;
        }

        #region POST

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert_Course(int lectureId, int moduleId, string day, string startTime, string endTime)
        {
            int classes = await classesRepositoryAsync.Insert(lectureId, moduleId, day, startTime, endTime);

            return Ok(classes);
        }

        #endregion

        #region SELECT

        [HttpGet]
        [Route("lecture")]
        public async Task<IActionResult> Select_LectureId(int lectureId)
        {
            var classes = await classesRepositoryAsync.Select_Classes_LectureId(lectureId);

            if(classes == null || classes.Count == 0)
            {
                return BadRequest("No classes found");
            }
            else
            {
                return Ok(classes);
            }
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult>Delete(int classId)
        {
            int classes = await classesRepositoryAsync.Delete(classId);

            return Ok(classes);
        }

        #endregion
    }
}
