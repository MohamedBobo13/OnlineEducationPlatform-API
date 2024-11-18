using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;


        public QuestionsController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _questionManager.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetByIdAsync(int Id)
        {
            var question = await _questionManager.GetByIdAsync(Id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpGet]
        [Route("Exam/{CourseId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]

        public async Task<ActionResult> GetCourseExamAsync(int CourseId)
        {
            if (!await _questionManager.CourseIdExist(CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            return Ok(await _questionManager.GetCourseExamAsync(CourseId));
        }

        [HttpPost]
        [Route("Exam")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> AddExamAsync(QuestionExamAddDto questionExamAddDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _questionManager.CourseIdExist(questionExamAddDto.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            if (!await _questionManager.ExamIdExist(questionExamAddDto.ExamId))
            {
                return BadRequest("Exam Id Not Valid");
            }
            await _questionManager.AddExamAsync(questionExamAddDto);
            return NoContent();
        }

        [HttpPut]
        [Route("Exam/{Id}")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> UpdateExamAsync(int Id, QuestionExamUpdateDto questionExamUpdateDto)
        {
            if (!await _questionManager.IdForExam(Id))
            {
                return BadRequest("Id Not Valid For Exam");
            }
            if (Id != questionExamUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _questionManager.ExamIdExist(questionExamUpdateDto.ExamId))
            {
                return BadRequest("Exam Id Not Valid");
            }
            await _questionManager.UpdateExamAsync(questionExamUpdateDto);
            return NoContent();
        }

        [HttpGet]
        [Route("Quiz/{CourseId}")]
        [Authorize(Roles = "Admin,Instructor,Student")]


        public async Task<ActionResult> GetCourseQuizAsync(int CourseId)
        {
            if (!await _questionManager.CourseIdExist(CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            return Ok(await _questionManager.GetCourseQuizAsync(CourseId));
        }

        [HttpPost]
        [Route("Quiz")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> AddQuizAsync(QuestionQuizAddDto questionQuizAddDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _questionManager.CourseIdExist(questionQuizAddDto.CourseId))
            {
                return BadRequest("Course Id Not Valid");
            }
            if (!await _questionManager.QuizIdExist(questionQuizAddDto.QuizId))
            {
                return BadRequest("Quiz Id Not Valid");
            }
            await _questionManager.AddQuizAsync(questionQuizAddDto);
            return NoContent();
        }
        
        [HttpPut]
        [Route("Quiz/{Id}")]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> UpdateQuizAsync(int Id, QuestionQuizUpdateDto questionQuizUpdateDto)
        {
            if (!await _questionManager.IdForQuiz(questionQuizUpdateDto.Id))
            {
                return BadRequest("Id Not Valid For Quiz");
            }
            if (Id != questionQuizUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _questionManager.QuizIdExist(questionQuizUpdateDto.QuizId))
            {
                return BadRequest("Quiz Id Not Valid");
            }
            await _questionManager.UpdateQuizAsync(questionQuizUpdateDto);
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Instructor")]

        public async Task<ActionResult> DeleteAsync(int Id)
        {
           var question= await _questionManager.DeleteAsync(Id);
            if (question == true)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}