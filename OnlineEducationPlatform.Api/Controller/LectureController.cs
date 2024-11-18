using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureManager _lectureManager;

        public LectureController(ILectureManager lectureManager)
        {
            _lectureManager = lectureManager;
        }
        [HttpGet]
      
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<IActionResult> GetAllLectures()
        {
            var lectures = await _lectureManager.GetAllAsync();
            if (lectures != null)
            {
                return Ok(lectures);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetLecture(int id)
        {
            var lecture = await _lectureManager.GetByIdAsync(id);
            if (lecture != null)
            {
                return Ok(lecture);
            }
            return NotFound();
        }



        [HttpDelete("{id:int}")]
        //Instructor only can delete lecture
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> RemoveLecture(int id)
        {
            var lecture = await _lectureManager.GetByIdAsync(id);
            if (lecture != null)
            {
                var IsDeleted = await _lectureManager.DeleteAsync(id);
                if (IsDeleted)
                {
                    return Ok("Lecture Deleted Successfully");
                }
                return StatusCode(500, "An error occurred while deleting the lecture.");

            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]

        //Instructor only can add Lecture
        public async Task<ActionResult<LectureAddDto>> AddLecture(LectureAddDto lectureAddDto)
        {
            if (!await _lectureManager.CourseIdExist(lectureAddDto.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            var lecture = _lectureManager.AddAsync(lectureAddDto);
            if (lecture != null)
            {
                return Ok("Addition Succeeded");

            }
            return BadRequest("Failed To Add Lecture");

        }
        [HttpPut("{id:int}")]
     
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> UpdateLecture(int id, LectureUpdateDto lectureUpdateDto)
        {

            if (id != lectureUpdateDto.Id)
            {
                return BadRequest("Id is not Identical");
            }
            if (!await _lectureManager.IdExist(lectureUpdateDto.Id))
            {
                return BadRequest("Id Not Exist");
            }
            if (!await _lectureManager.CourseIdExist(lectureUpdateDto.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
           await _lectureManager.UpdateAsync(lectureUpdateDto);
            return Ok("Lecture is Updated");

        }
    }
}
