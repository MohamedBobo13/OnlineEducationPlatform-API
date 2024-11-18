using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.QuizDto;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controllers.Quiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizManager _context;

        public QuizController(IQuizManager context)
        {
            _context = context;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetAll()
        {
            var quiz = await _context.GetAllAsync();
            if (quiz !=null)
            {
                return Ok(quiz);
            }
             return NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetQuizById(int id)
        {
        var quiz = await _context.GetByIdAsync(id);
        if (quiz == null)
        {
            return NotFound();
        }
        return Ok(quiz);

    }

        [HttpPost]
       
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult<QuizAddDto>> CreateQuiz(QuizAddDto quiz)
        {
            if (!await _context.CourseIdExist(quiz.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            if (!await _context.LectureIdExist(quiz.LectureId))
            {
                return BadRequest("Lecture Id Not Valid");
            }
            var addquiz =await _context.AddAsync(quiz);
                if (addquiz != null)
                {
                    return Ok("Addition Succeeded");
                }
                else
                {
                    return BadRequest("Failed to add quiz");

                }
            
            
        }

        [HttpPut("{id}")]
        
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<IActionResult> UpdateQuiz(int id, QuizUpdateDto quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest("Id not Identical");
            }
            if (!await _context.CourseIdExist(quiz.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            if (!await _context.LectureIdExist(quiz.LectureId))
            {
                return BadRequest("Lecture Id Not Valid");
            }
            var existquiz = await _context.GetByIdAsync(quiz.Id);
            if (existquiz is null)
            {
                return NotFound();
            }
            var updatequiz = await _context.UpdateAsync(quiz);
            if (updatequiz != null)
            {
                return Ok("Updating Succeded");
            }
            else
            {
                return BadRequest("Failed to update Quiz");

            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            var existQuiz = await _context.GetByIdAsync(id);
            if (existQuiz is null)
            {
                return NotFound();
            }
             await _context.DeleteAsync(id);
            return Ok("Deletion Succeeded");
        }
    }
}
