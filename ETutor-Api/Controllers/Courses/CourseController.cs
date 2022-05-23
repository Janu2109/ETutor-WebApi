using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Courses
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepositoryAsync courseRepositoryAsync;
        public CourseController(ICourseRepositoryAsync courseRepositoryAsync)
        {
            this.courseRepositoryAsync = courseRepositoryAsync;
        }

        #region SELECT

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select_Courses_All()
        {
            var courses = await courseRepositoryAsync.Select_Courses_All();

            if (null == courses || courses.Count < 1)
            {
                return BadRequest("No Courses Found");
            }
            else
            {
                return Ok(courses);
            }
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Insert_Course(string name, string description, string duration)
        {
            int course = await courseRepositoryAsync.Insert(name, description, duration);

            return Ok(course);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete_Course(int id)
        {
            int course = await courseRepositoryAsync.Delete_Course(id);

            return Ok(course);
        }

        #endregion

        #region UPDATE

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update_Course(int id, string name, string duration, string description)
        {
            int course = await courseRepositoryAsync.Update_Course(id, name, duration, description);

            return Ok(course);
        }

        #endregion


    }
}
