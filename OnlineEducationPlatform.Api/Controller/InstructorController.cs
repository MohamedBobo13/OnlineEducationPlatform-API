using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.InstructorDto;
using OnlineEducationPlatform.BLL.Dto.StudentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.InstructorManager;
using OnlineEducationPlatform.BLL.Manager.StudentManager;

namespace OnlineEducationPlatform.Api.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class InstructorController : ControllerBase
    {
        private readonly IInstructorManager _instructormanager;

        public InstructorController(IInstructorManager instructormanager)
        {
            _instructormanager = instructormanager;
        }

        [HttpGet]

        public async Task<ActionResult<ServiceResponse<InstructorReadDto>>> GetAll()
        {
            var serviceResponse = await _instructormanager.GetAllInstructorsAsync();
          
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpGet("{InstructorId}")]
        public async Task<ActionResult<ServiceResponse<InstructorReadDto>>> GetById(string InstructorId)
        {
            var serviceResponse = await _instructormanager.GetInstructorbyid(InstructorId);
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }
        [HttpDelete("SoftDelete/{InstructorId}")]
        //  [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> SodtDeleteInstructor(string InstructorId)
        {

            var response = await _instructormanager.softdeleteInstructor(InstructorId);
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
