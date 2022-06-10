using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Attendance
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepositoryAsync attendanceRepositoryAsync;
        public AttendanceController(IAttendanceRepositoryAsync attendanceRepositoryAsync)
        {
            this.attendanceRepositoryAsync = attendanceRepositoryAsync;
        }

        #region POST

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert(int moduleId, int userId, string date)
        {
            int attending = await attendanceRepositoryAsync.Insert(moduleId, userId, date);

            return Ok(attending);
        }

        #endregion
    }
}
