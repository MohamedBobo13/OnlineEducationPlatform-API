using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.BLL.Dto.VideoDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFFileController : ControllerBase
    {
        private readonly IPdfFileManager _pdfFileManager;

        public PDFFileController(IPdfFileManager pdfFileManager)
        {
            _pdfFileManager = pdfFileManager;
        }

        [HttpGet]
      
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<IActionResult> GetAllPdfs()
        {
            var pdfs = await _pdfFileManager.GetAllAsync();
            if (pdfs != null)
            {
                return Ok(pdfs);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetPdf(int id)
        {
            var pdf = await _pdfFileManager.GetByIdAsync(id);
            if (pdf != null)
            {
                return Ok(pdf);
            }
            return NotFound();
        }



        [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> RemovePdf(int id)
        {
            var pdf = await _pdfFileManager.GetByIdAsync(id);
            if (pdf != null)
            {
                var IsDeleted = await _pdfFileManager.DeleteAsync(id);
                if (IsDeleted)
                {
                    return Ok("Pdf Deleted Successfully");
                }
                return StatusCode(500, "An error occurred while deleting the Pdf.");

            }
            return NotFound();
        }
        [HttpPost]
    [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult<PdfFileAddDto>> AddPdf(PdfFileAddDto pdfFileAddDto)
        {
            if (!await _pdfFileManager.LectureIdExist(pdfFileAddDto.LectureId))
            {
                return BadRequest("Lecture Id Not Valid");
            }
            var pdf = _pdfFileManager.AddAsync(pdfFileAddDto);
            if (pdf != null)
            {
                return Ok("Addition Succeeded");

            }
            return BadRequest("Failed To Add Pdf");

        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> UpdatePdf(int id, PdfFileUpdateDto pdfFileUpdateDto)
        {
            if (id != pdfFileUpdateDto.Id)
            {
                return BadRequest("Id is not Identical");
            }
            if (!await _pdfFileManager.IdExist(pdfFileUpdateDto.Id))
            {
                return BadRequest("Id Not Exist");
            }
            if (!await _pdfFileManager.LectureIdExist(pdfFileUpdateDto.LectureId))
            {
                return BadRequest("Lecture Id Not Valid");
            }
             await _pdfFileManager.UpdateAsync(pdfFileUpdateDto);
            
            return Ok("Pdf is Updated");

            
           
        }
    }
}
