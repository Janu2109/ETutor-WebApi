using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.AdminClasses
{
    [Route("api/adminclasses")]
    [ApiController]
    public class AdminClassesController : ControllerBase
    {
        private readonly IAdminClassesRepositoryAsync adminClassesRepositoryAsync;
        public AdminClassesController(IAdminClassesRepositoryAsync adminClassesRepositoryAsync)
        {
            this.adminClassesRepositoryAsync = adminClassesRepositoryAsync;
        }

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select_Marks()
        {
            var classes = await adminClassesRepositoryAsync.Select_Classes();

            if (null == classes || classes.Count < 1)
            {
                return BadRequest("No Marks Found");
            }
            else
            {
                return Ok(classes);
            }
        }
    }
}
