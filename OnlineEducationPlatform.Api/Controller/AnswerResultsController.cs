using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.Manager.Answerresultmanager;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class AnswerResultsController : ControllerBase
    {
        private readonly IAnswerResultManager _answerResultManager;

        public AnswerResultsController(IAnswerResultManager answerResultManager)
        {
            _answerResultManager = answerResultManager;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Instructor,Student")]


        public async Task<ActionResult> GetAll()
        {
            return Ok(await _answerResultManager.GetAllAsync());
        }
        [HttpGet]
        [Route("{Id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]


        public async Task<ActionResult> GetById(int Id)
        {
            var answerResult = await _answerResultManager.GetByIdAsync(Id);
            if (answerResult == null)
            {
                return NotFound();
            }
            return Ok(answerResult);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Student")]


        public async Task<ActionResult> Add(AnswerResultAddDto answerResultAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _answerResultManager.StudentIdExist(answerResultAddDto.StudentId))
            {
                return BadRequest("Student Id Not Valid");
            }
            if (!await _answerResultManager.QuestionIdExist(answerResultAddDto.QuestionId))
            {
                return BadRequest("Question Id Not Valid");
            }
            if (!await _answerResultManager.AnswerIdExist(answerResultAddDto.AnswerId))
            {
                return BadRequest("Answer Id Not Valid");
            }
            await _answerResultManager.AddAsync(answerResultAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        [Authorize(Roles = "Admin,Student")]

        public async Task<ActionResult> Update(int Id, AnswerResultUpdateDto answerResultUpdateDto)
        {
            if (!await _answerResultManager.IdExist(answerResultUpdateDto.Id))
            {
                return BadRequest("Id Not Exist");
            }
            if (Id != answerResultUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _answerResultManager.StudentIdExist(answerResultUpdateDto.StudentId))
            {
                return BadRequest("Student Id Not Valid");
            }
            if (!await _answerResultManager.QuestionIdExist(answerResultUpdateDto.QuestionId))
            {
                return BadRequest("Question Id Not Valid");
            }
            if (!await _answerResultManager.AnswerIdExist(answerResultUpdateDto.AnswerId))
            {
                return BadRequest("Answer Id Not Valid");
            }
            await _answerResultManager.UpdateAsync(answerResultUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Delete(int Id)
        {
           var answerresult= await _answerResultManager.DeleteAsync(Id);
            if (answerresult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
