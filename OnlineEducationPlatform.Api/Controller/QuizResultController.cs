using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto;
using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.quizresultmanager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        private readonly IQuizResultManager _quizResultManager;

        public QuizResultController(IQuizResultManager quizResultManager)
        {
            _quizResultManager = quizResultManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult<ServiceResponse<quizresultreaddto>>> GetAll()
        {
            var serviceResponse = await _quizResultManager.GetAllQuizResults();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No QuizResults yet !!")
            {
                return Ok(serviceResponse.Message);
            }
            else if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }


        [HttpGet("Get/{StudentId}/{QuizId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult<ServiceResponse<QuizResult>>> GetStudentResult(string StudentId ,int QuizId)
        {

            var response = await _quizResultManager.GetQuizResultAsync(StudentId,QuizId);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }

        }
        [HttpPost]
        //   [Authorize(Roles ="Admin")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult<ServiceResponse<quizresultwithoutiddto>>> CreateQuizResult([FromBody] quizresultwithoutiddto quizresultadddto)
        {

            var response = await _quizResultManager.CreateQuizresultAsync(quizresultadddto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }


        }
        [HttpDelete("SoftDelete/{StudentId}/{QuizId}")]
         [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> SoftDeleteQuizresult(string StudentId, int QuizId)
        {

            var response = await _quizResultManager.softdeletequizresult(StudentId, QuizId);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }

        [HttpDelete("HardDelete/{studentId}/{QuizId}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> HardDeletequizresult(string studentId, int QuizId)
        {

            var response = await _quizResultManager.HardDeleteEQuizresulttByStudentAndquizsync(studentId, QuizId);
            if (response.Success)
            {
                return Ok(response.Message);
            }

            else
            {
                return BadRequest(response.Message);
            }


        }
        [HttpGet("GetAllSoftDeleted")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<quizresultwithoutiddto>>> GetAllSoftDeletedQuizresults()
        {
            var serviceResponse = await _quizResultManager.GetAllSoftDeletedQuizresultsAsync();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No Soft Deleted Quiz results yet !!")
            {
                return Ok(serviceResponse.Message);
            }
            else if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult<ServiceResponse<bool>>> Updatequizresult(int Id, updatequizresultdto quizresultreaddto)
        {
            if (Id != quizresultreaddto.id) { return BadRequest(new { message = "Id is not identical" }); }

            var serviceResponse = await _quizResultManager.updatequizresultbyid(quizresultreaddto);

            if (serviceResponse.Success)
            {
                return Ok(serviceResponse.Message);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpGet("{StudentId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult<ServiceResponse<quizresultreaddto>>> GetQuizResultsByStudentIdAsync(string StudentId)
        {
            var response = await _quizResultManager.GetStudentresultssByStudentIdAsync(StudentId);

            if (int.Parse(StudentId) <= 0)
            {
                return BadRequest("Invalid Student Id.");
            }
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }
        [HttpGet("GetAll/{QuizId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<quizresultreaddto>>> GetQuizResultsByquizIdAsync(int QuizId)
        {
            var response = await _quizResultManager.GetstudentresultsByQuizIdAsync(QuizId);

            if (QuizId <= 0)
            {
                return BadRequest("Invalid Quiz ID.");
            }
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }

    }
}
