using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.ExamResultDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.ExamResultmanager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultmanager _examResultmanager;

        public ExamResultController(IExamResultmanager examResultmanager)
        {
            _examResultmanager = examResultmanager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult<ServiceResponse<Examresultreaddto>>> GetAll()
        {
            var serviceResponse = await _examResultmanager.GetAllExamResults();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No Exam Results yet !!")
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


        [HttpGet("Get/{StudentId}/{ExamId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult<ServiceResponse<QuizResult>>> GetStudentResult(string StudentId, int ExamId)
        {

            var response = await _examResultmanager.GetExamResultAsync(StudentId, ExamId);
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

        public async Task<ActionResult<ServiceResponse<Examresultwithoutiddto>>> CreateExamResult([FromBody] Examresultwithoutiddto examresultadddto)
        {

            var response = await _examResultmanager.CreateexamresultAsync(examresultadddto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {


                return BadRequest(response);

            }


        }
        [HttpDelete("SoftDelete/{StudentId}/{ExamId}")]
          [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> SoftDeleteExamresult(string StudentId, int ExamId)
        {

            var response = await _examResultmanager.softdeleteexamresult(StudentId, ExamId);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }

        [HttpDelete("HardDelete/{studentId}/{ExamId}")]
         [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> HardDeleteExamresult(string studentId, int ExamId)
        {

            var response = await _examResultmanager.HardDeleteExamresulttByStudentAndquizsync(studentId, ExamId);
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

        public async Task<ActionResult<ServiceResponse<Examresultwithoutiddto>>> GetAllSoftDeletedExamresults()
        {
            var serviceResponse = await _examResultmanager.GetAllSoftDeletedexamresultsAsync();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No Soft Deleted Exam results yet !!")
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

        public async Task<ActionResult<ServiceResponse<bool>>> UpdateExamresult(int Id, updateexamresultdto examresultupdatedto)
        {
            if (Id != examresultupdatedto.id) { return BadRequest(new { message = "Id is not identical" }); }

            var serviceResponse = await _examResultmanager.updateexamresultbyid(examresultupdatedto);

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

        public async Task<ActionResult<ServiceResponse<Examresultreaddto>>> GetExamResultsByStudentIdAsync(string StudentId)
        {
            var response = await _examResultmanager.GetStudentresultssByStudentIdAsync(StudentId);

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
        [HttpGet("GetAll/{ExamId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Examresultreaddto>>> GetExamResultsByExamIdAsync(int ExamId)
        {
            var response = await _examResultmanager.GetstudentresultsByExamIdAsync(ExamId);

            if (ExamId <= 0)
            {
                return BadRequest("Invalid Exam ID.");
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
