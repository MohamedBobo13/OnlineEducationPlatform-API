using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.ExamDto;
using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.BLL.Dto.QuizDto;
using OnlineEducationPlatform.BLL.Manager.ExamManager;
using OnlineEducationPlatform.BLL.Manager.QuizManager;

namespace OnlineEducationPlatform.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamManager _context;

        public ExamController(IExamManager context)
        {
            _context = context;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetAll()
        {
            var exam = await _context.GetAllAsync();
            if (exam != null)
            {
                return Ok(exam);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]


        public async Task<ActionResult> GetExamById(int id)
        {
            var exam = await _context.GetByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);

        }

        [HttpPost]
       
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult<ExamAddDto>> CreateQuiz(ExamAddDto exam)
        {
            if (!await _context.CourseIdExist(exam.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            var addexam = await _context.AddAsync(exam);
            if (  exam != null)
            {
                return Ok("Addition Succeeded");
            }
            else
            {
                return BadRequest("Failed to add Exam");

            }


        }

        [HttpPut("{id}")]
                          
        
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<IActionResult> UpdateExam(int id, ExamUpdateDto exam)
        {
            if (id != exam.Id)
            {
                return BadRequest("Id not Identical");
            }
            if (!await _context.CourseIdExist(exam.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            var existexam = await _context.GetByIdAsync(exam.Id);
            if (existexam is null)
            {
                return NotFound();
            }
            var updateexam = await _context.Update(exam);
            if (updateexam != null)
            {
                return Ok("Updating Succeded");
            }
            else
            {
                return BadRequest("Failed to update Exam");

            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var existexam = await _context.GetByIdAsync(id);
            if (existexam is null)
            {
                return NotFound();
            }
            await _context.DeleteAsync(id);
            return Ok("Deletion Succeeded");
        }
    }
}
