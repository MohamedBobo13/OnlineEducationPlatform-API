using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.Manager.EnrollmentManager;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IenrollmentManager _enrollmentmanager;

        public EnrollmentController(IenrollmentManager enrollmentmanager)
        {
            _enrollmentmanager = enrollmentmanager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Instructor")]


        public async Task<ActionResult<ServiceResponse<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetAll()
        {
            var serviceResponse = await _enrollmentmanager.GetAllEnrollments();
              if (serviceResponse.Success && serviceResponse.Message == "There Are No Enrollments yet !!")
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

        public async Task<ActionResult<ServiceResponse<bool>>> updateEnrollment(int Id,updateenrollmentdto updateenrollmentdto)
        {
            if (Id != updateenrollmentdto.Id) { return BadRequest(new {message ="Id is not identical"}); }

            var serviceResponse = await _enrollmentmanager.updateenrollmentbyid(updateenrollmentdto);
           
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse.Message);
            }

            else
            {


                return BadRequest(serviceResponse.Message);

            }

        }

        [HttpGet("GetAllSoftDeleted")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<EnrollmentDtowWithStatusanddDate>>> GetAllSoftDeletedEnrollments()
        {
            var serviceResponse = await _enrollmentmanager.GetAllSoftDeletedEnrollmentsAsync();
            if (serviceResponse.Success && serviceResponse.Message == "There Are No Soft Deleted Enrollments yet  !!")
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





        [HttpPost]

        [Authorize(Roles = "Admin,Instructor,Student")]


        public async Task<ActionResult<ServiceResponse<EnrollmentDtowWithStatusanddDate>>> CreateEnrollment([FromBody] EnrollmentDto enrollmentDto)
        {

             var response = await _enrollmentmanager.CreateEnrollmentAsync(enrollmentDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                 
                
                 return BadRequest(response.Message);
               
            }


        }
        [HttpDelete("SoftDelete/{StudentId}/{CourseId}")]
       
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> SoftDeleteEnrollment(string StudentId,int CourseId)
        {

            var response = await _enrollmentmanager.UnenrollFromCourseByStudentAndCourseIdAsync(StudentId,CourseId);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {


                return BadRequest(response.Message);

            }


        }
        [HttpDelete("HardDelete/{studentId}/{courseId}")]
     
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<ServiceResponse<bool>>> HardDeleteEnrollment( string studentId, int courseId)
        {

            var response = await _enrollmentmanager.HardDeleteEnrollmentByStudentAndCourseAsync(studentId, courseId);
            if (response.Success )
            {
                return Ok(response.Message);
            }
            
            else
            {
                return BadRequest(response.Message);
            }


        }
       
        [HttpGet("GetAll/{CourseId}")]
     
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult<ServiceResponse<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetAllEnrollmentsByCourseId(int CourseId)
        {
            var response = await _enrollmentmanager.GetEnrollmentsByCourseIdAsync(CourseId);

            if (CourseId <= 0)
            {
                return BadRequest("Invalid course ID.");
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
        [HttpGet("{StudentId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult<ServiceResponse<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetAllEnrollmentsByStudentId(string StudentId)
        {
            var response = await _enrollmentmanager.GetEnrollmentsByStudentIdAsync(StudentId);

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


    }
}
