using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.StudentsEnrolled
{
    [Route("api/studentsEnrolled")]
    [ApiController]
    public class StudentsEnrolledController : ControllerBase
    {
        private readonly IStudentsEnrolledRepositoryAsync studentsEnrolledRepositoryAsync;
        public StudentsEnrolledController(IStudentsEnrolledRepositoryAsync studentsEnrolledRepositoryAsync)
        {
            this.studentsEnrolledRepositoryAsync = studentsEnrolledRepositoryAsync;
        }

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select()
        {
            var students = await studentsEnrolledRepositoryAsync.Select();

            if (null == students || students.Count < 1)
            {
                return BadRequest("No Enrollements Found");
            }
            else
            {
                return Ok(students);
            }
        }
    }
}
