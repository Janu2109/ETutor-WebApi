using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Enrollment
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IStudentEnrollmentRepositoryAsync studentEnrollmentRepositoryAsync;
        public EnrollmentController(IStudentEnrollmentRepositoryAsync studentEnrollmentRepositoryAsync)
        {
            this.studentEnrollmentRepositoryAsync = studentEnrollmentRepositoryAsync;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Enroll(int userId, int courseId)
        {
            int enrollment = await studentEnrollmentRepositoryAsync.Insert(userId, courseId);

            return Ok(enrollment);
        }
    }
}
