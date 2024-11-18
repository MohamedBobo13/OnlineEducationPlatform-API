using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.Manager.Answermanager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
[Authorize(Roles = "Admin,Instructor")]

    public class AnswersController : ControllerBase
    {
        private readonly IAnswerManager _answerManager;


        public AnswersController(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }
        

        [HttpGet]
       
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _answerManager.GetAllAsync());
        }
        [HttpGet]
        [Route("{Id}")]

        public async Task<ActionResult> GetById(int Id)
        {
            var answer = await _answerManager.GetByIdAsync(Id);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }
        [HttpPost]

        public async Task<ActionResult> Add(AnswerAddDto answerAddDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!await _answerManager.QuestionIdExist(answerAddDto.QuestionId))
            {
                return BadRequest("Question Id Not Valid");
            }
            await _answerManager.AddAsync(answerAddDto);
            return Created();
        }
        [HttpPut]
        [Route("{Id}")]

        public async Task<ActionResult> Update(int Id, AnswerUpdateDto answerUpdateDto)
        {
            if(!await _answerManager.IdExist(answerUpdateDto.Id))
            {
                return BadRequest("Id Not Exist");
            }
            if (Id != answerUpdateDto.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _answerManager.QuestionIdExist(answerUpdateDto.QuestionId))
            {
                return BadRequest("Question Id Not Valid");
            }
            await _answerManager.UpdateAsync(answerUpdateDto);
            return NoContent();
        }
        [HttpDelete]

        public async Task<ActionResult> Delete(int Id)
        {
           var answer= await _answerManager.DeleteAsync(Id);
            if (answer == true)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}