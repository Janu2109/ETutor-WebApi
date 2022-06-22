using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Assessments
{
    [Route("api/assessments")]
    [ApiController]
    public class AssessmentsController : ControllerBase
    {
        private readonly IAssessmentsRepositoryAsync assessmentsRepositoryAsync;
        public AssessmentsController(IAssessmentsRepositoryAsync assessmentsRepositoryAsync) 
        { 
            this.assessmentsRepositoryAsync = assessmentsRepositoryAsync;
        }

        #region POST

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert(int moduleId, string title, string questionOneQ, string questionOneA, string questionOneO, string questionTwoQ, string questionTwoA, string questionTwoO, string questionThreeQ, string questionThreeA, string questionThreeO, string questionFourQ, string questionFourA, string questionFourO, string questionFiveQ, string questionFiveA, string questionFiveO)
        {
            int assessment = await assessmentsRepositoryAsync.Insert(moduleId, title, questionOneQ, questionOneA, questionOneO, questionTwoQ, questionTwoA, questionTwoO, questionThreeQ, questionThreeA, questionThreeO, questionFourQ, questionFourA, questionFourO, questionFiveQ, questionFiveA, questionFiveO);

            return Ok(assessment);
        }

        #endregion

        #region SELECT

        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Select_Assessments()
        {
            var assessments = await assessmentsRepositoryAsync.Select_Assessments();

            if (null == assessments || assessments.Count < 1)
            {
                return BadRequest("No Modules Found");
            }
            else
            {
                return Ok(assessments);
            }
        }

        #endregion
    }
}
