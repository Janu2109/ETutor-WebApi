using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.AdminModules
{
    [Route("api/adminmodules")]
    [ApiController]
    public class AdminModulesController : ControllerBase
    {
        private readonly IAdminModulesRepositoryAsync adminModulesRepositoryAsync;
        public AdminModulesController(IAdminModulesRepositoryAsync adminModulesRepositoryAsync)
        {
            this.adminModulesRepositoryAsync = adminModulesRepositoryAsync;
        }

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select_Assessments()
        {
            var modules = await adminModulesRepositoryAsync.Select_Modules();

            if (null == modules || modules.Count < 1)
            {
                return BadRequest("No Modules Found");
            }
            else
            {
                return Ok(modules);
            }
        }
    }
}
