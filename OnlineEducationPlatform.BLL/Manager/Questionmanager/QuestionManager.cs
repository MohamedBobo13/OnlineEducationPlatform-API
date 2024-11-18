using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using OnlineEducationPlatform.DAL.Repositories;

namespace OnlineEducationPlatform.BLL.Manager.Questionmanager
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepo _questionRepo;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionRepo questionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QuestionReadDto>> GetAllAsync()
        {
            var questions = await _questionRepo.GetAllAsync();
            return _mapper.Map<List<QuestionReadDto>>(questions);
        }

        public async Task<IEnumerable<QuestionCourseExamReadDto>> GetCourseExamAsync(int courseId)
        {
            var questionsCourseExam = await _questionRepo.GetCourseExamAsync(courseId);
            if (questionsCourseExam == null)
            {
                return null;
            }
            return _mapper.Map<List<QuestionCourseExamReadDto>>(questionsCourseExam);
        }

        public async Task<IEnumerable<QuestionCourseQuizReadDto>> GetCourseQuizAsync(int courseId)
        {
            var questionsCourseQuiz = await _questionRepo.GetCourseQuizAsync(courseId);
            if (questionsCourseQuiz == null)
            {
                return null;
            }
            return _mapper.Map<List<QuestionCourseQuizReadDto>>(questionsCourseQuiz);
        }


        public async Task<QuestionReadDto> GetByIdAsync(int id)
        {
            var question = await _questionRepo.GetByIdAsync(id);

            if (question == null)
                return null;

            return _mapper.Map<QuestionReadDto>(question);
        }
        public async Task AddExamAsync(QuestionExamAddDto questionExamAddDto)
        {
            await _questionRepo.AddAsync(_mapper.Map<Question>(questionExamAddDto));
        }

        public async Task AddQuizAsync(QuestionQuizAddDto questionQuizAddDto)
        {
            await _questionRepo.AddAsync(_mapper.Map<Question>(questionQuizAddDto));
        }
        public async Task UpdateExamAsync(QuestionExamUpdateDto questionExamUpdateDto)
        {
            var existingQuestionExam = await _questionRepo.GetByIdAsync(questionExamUpdateDto.Id);
            if (existingQuestionExam == null)
            {
                return;
            }
            _questionRepo.UpdateAsync(_mapper.Map(questionExamUpdateDto, existingQuestionExam));
        }

        public async Task UpdateQuizAsync(QuestionQuizUpdateDto questionQuizUpdateDto)
        {
            var existingQuestionQuiz = await _questionRepo.GetByIdAsync(questionQuizUpdateDto.Id);
            if (existingQuestionQuiz == null)
            {
                return;
            }
            _questionRepo.UpdateAsync(_mapper.Map(questionQuizUpdateDto, existingQuestionQuiz));
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var questionModel = await _questionRepo.GetByIdAsync(id);
            if (questionModel != null)
            {
                await _questionRepo.DeleteAsync(questionModel);
                return true;
            }
            return false;
        }
        public async Task<bool> IdForExam(int questionId)
        {
            bool idForExam = await _questionRepo.IdForExam(questionId);
            if (idForExam)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IdForQuiz(int questionId)
        {

            bool idForQuiz = await _questionRepo.IdForQuiz(questionId);
            if (idForQuiz)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> QuizIdExist(int quizId)
        {
            bool quizExist = await _questionRepo.QuizIdExist(quizId);
            if (quizExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExamIdExist(int examId)
        {
            bool examExist = await _questionRepo.ExamIdExist(examId);
            if (examExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CourseIdExist(int courseId)
        {
            bool courseExist = await _questionRepo.CourseIdExist(courseId);
            if (courseExist)
            {
                return true;
            }
            return false;
        }
    }
}