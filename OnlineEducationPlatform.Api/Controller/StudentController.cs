using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.Dto.StudentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.StudentManager;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class StudentController : ControllerBase
    {
        private readonly Istudentmanager _studentmanager;

        public StudentController(Istudentmanager studentmanager)
        {
            _studentmanager = studentmanager;
        }

        [HttpGet]

        public async Task<ActionResult<ServiceResponse<studentreaddto>>> GetAll()
        {
            var serviceResponse = await _studentmanager.GetAllStudentsAsync();
           
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpGet("{StudentId}")]
        public async Task<ActionResult<ServiceResponse<studentreaddto>>> GetById(string StudentId)
        {
            var serviceResponse = await _studentmanager.Getstudentbyid(StudentId);
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }
           
           else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpDelete("SoftDelete/{StudentId}")]
        //  [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> SoftDeleteStudent(string StudentId)
        {

            var response = await _studentmanager.softdeleteStudent(StudentId);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }
    }
}
