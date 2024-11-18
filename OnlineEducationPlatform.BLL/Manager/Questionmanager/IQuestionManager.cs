using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.BLL.Manager.Questionmanager
{
    public interface IQuestionManager
    {
        Task<IEnumerable<QuestionReadDto>> GetAllAsync();

        Task<IEnumerable<QuestionCourseExamReadDto>> GetCourseExamAsync(int courseId);

        Task<IEnumerable<QuestionCourseQuizReadDto>> GetCourseQuizAsync(int courseId);

        Task<QuestionReadDto> GetByIdAsync(int id);

        Task AddQuizAsync(QuestionQuizAddDto questionQuizAddDto);

        Task AddExamAsync(QuestionExamAddDto questionExamAddDto);

        Task UpdateExamAsync(QuestionExamUpdateDto questionExamUpdateDto);

        Task UpdateQuizAsync(QuestionQuizUpdateDto questionQuizUpdateDto);

        Task <bool>DeleteAsync(int id);

        Task<bool> IdForExam(int questionId);

        Task<bool> IdForQuiz(int questionId);

        Task<bool> QuizIdExist(int quizId);

        Task<bool> ExamIdExist(int examId);

        Task<bool> CourseIdExist(int courseId);
    }
}