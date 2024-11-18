using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.VideoDto;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVedioManager _vedioManager;

        public VideoController(IVedioManager vedioManager)
        {
            _vedioManager = vedioManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<IActionResult> GetAllVideos()
        {
            var videos = await _vedioManager.GetAllAsync();
            if (videos != null)
            {
                return Ok(videos);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetVideo(int id)
        {
            var video = await _vedioManager.GetByIdAsync(id);
            if (video != null)
            {
                return Ok(video);
            }
            return NotFound();
        }



        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> RemoveVideo(int id)
        {
            var video = await _vedioManager.GetByIdAsync(id);
            if (video != null)
            {
                var IsDeleted = await _vedioManager.DeleteAsync(id);
                if (IsDeleted)
                {
                    return Ok("Video Deleted Successfully");
                }
                return StatusCode(500, "An error occurred while deleting the Video.");

            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult<VedioAddDto>> AddVideo(VedioAddDto vedioAddDto)
        {
            if (!await _vedioManager.LectureIdExist(vedioAddDto.LectureId))
            {
                return BadRequest("Lecture Id Not Valid");
            }
            var video = _vedioManager.AddAsync(vedioAddDto);
            if (video != null)
            {
                return Ok("Addition Succeeded");

            }
            return BadRequest("Failed To Add Video");

        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> UpdateVideo(int id, VedioUpdateDto vedioUpdateDto)
        {
            if (id != vedioUpdateDto.Id)
            {
                return BadRequest("Id is not Identical");
            }
            if (!await _vedioManager.IdExist(vedioUpdateDto.Id))
            {
                return BadRequest("Id Not Exist");
            }
            if (!await _vedioManager.LectureIdExist(vedioUpdateDto.LectureId))
            {
                return BadRequest("Lecture Id Not Valid");
            }
            await _vedioManager.UpdateAsync(vedioUpdateDto);

            return Ok("Video is Updated");



        }
    }
}
