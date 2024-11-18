using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.ExamDto;
using OnlineEducationPlatform.BLL.Dto.QuizDto;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.QuizManager
{
    public class QuizManager : IQuizManager
    {
        private readonly IQuizRepo _quizRepo;
        private readonly IMapper _mapper;

        public QuizManager(IQuizRepo quizRepo,IMapper mapper)
        {
            _quizRepo = quizRepo;
            _mapper = mapper;
        }
        public async Task<List<QuizReadDto>> GetAllAsync()
        {
          
            var quizes=await _quizRepo.GetAll();
            return _mapper.Map<List<QuizReadDto>>(quizes);
        }

        public async Task<QuizReadDto> GetByIdAsync(int id)
        {
            var quiz = await _quizRepo.GetById(id);
            if (quiz is null)
            {
                return null;
            }
     
            return _mapper.Map<QuizReadDto>(quiz);
        }

        public async Task<QuizAddDto> AddAsync(QuizAddDto quizAddDto)

        {


            var quiz=_mapper.Map<Quiz>(quizAddDto);
            
           

            await _quizRepo.Add(quiz);
            var saveresult = await _quizRepo.CompleteAsync();
            if (saveresult == true)
            {
                return new QuizAddDto
                {
                   
                    LectureId = quiz.LectureId,
                    CourseId = quiz.CourseId,
                    Title = quiz.Title,
                    TotalMarks = quiz.TotalMarks,
                    TotalQuestions = quiz.TotalQuestions,
                };

            }
            return null;
           
        }


        public async Task<QuizUpdateDto> UpdateAsync(QuizUpdateDto quizUpdateDto)
        {
            var quiz = await _quizRepo.GetById(quizUpdateDto.Id);
            var existingquiz = await _quizRepo.quizExistsAsyncbyid(quizUpdateDto.Id);

            if (existingquiz == true)
            {
                quiz.Id = quizUpdateDto.Id;
                quiz.LectureId = quizUpdateDto.LectureId;
                quiz.CourseId = quizUpdateDto.CourseId;
                quiz.Title =    quizUpdateDto.Title;

               
                quiz.TotalMarks = quizUpdateDto.TotalMarks;
                quiz.TotalQuestions = quizUpdateDto.TotalQuestions;
               

                await _quizRepo.Update(quiz);
                var saveresult = await _quizRepo.CompleteAsync();
                if (saveresult == true)
                {
                    return new QuizUpdateDto
                    {

                        Id = quiz.Id,
                        CourseId = quiz.CourseId,
                        LectureId=quiz.LectureId,
                        Title = quiz.Title,
                        TotalMarks = quiz.TotalMarks,
                        TotalQuestions = quiz.TotalQuestions,
                       
                    };
                }
                else
                {
                    return null;
                }


            }
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            var quiz = await _quizRepo.GetById(id);
            if (quiz is null)
            {
                return;
            }
            await _quizRepo.Delete(quiz.Id);
        }
        public async Task<bool> CourseIdExist(int courseId)
        {
            bool courseExist = await _quizRepo.CourseIdExist(courseId);
            if (courseExist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> LectureIdExist(int LectureId)
        {
            bool Lectureexist = await _quizRepo.LectureIdExist(LectureId);
            if (Lectureexist)
            {
                return true;
            }
            return false;
        }
    
}
}
