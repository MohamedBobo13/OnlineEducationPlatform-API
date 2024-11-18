using OnlineEducationPlatform.BLL.Dtos;

namespace OnlineEducationPlatform.BLL.Manager.Answerresultmanager
{
    public interface IAnswerResultManager
    {
        Task<IEnumerable<AnswerResultReadDto>> GetAllAsync();

        Task<AnswerResultReadDto> GetByIdAsync(int id);

        Task AddAsync(AnswerResultAddDto answerResultAddDto);

        Task UpdateAsync(AnswerResultUpdateDto answerResultUpdateDto);

        Task <bool>DeleteAsync(int id);

        Task<bool> IdExist(int answerResultId);

        Task<bool> QuestionIdExist(int questionId);

        Task<bool> StudentIdExist(string studentId);

        Task<bool> AnswerIdExist(int answerId);

    }
}